    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    
    namespace ClassLibrary1
    {
        public class Class1
        {
            readonly string _path = Directory.GetCurrentDirectory();
    
            public void Demo()
            {
                IList<string> listOfUrls = new List<string>();
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/editicon.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/favorite-star-on.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/arrow_dsc_green.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/editicon.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/favorite-star-on.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/arrow_dsc_green.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/editicon.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/favorite-star-on.gif");
                listOfUrls.Add("http://i3.codeplex.com/Images/v16821/arrow_dsc_green.gif");
    
                BlockingCollection<Image> images = new BlockingCollection<Image>();
    
                Parallel.Invoke(
                    () =>                   // Task 1: load the images
                    {
                        Parallel.For(0, listOfUrls.Count, (i) =>
                            {
                                Image img = RetrieveImages(listOfUrls[i], i);
                                img.Tag = i;
                                images.Add(img);    // Add each image to the queue
                            });
                        images.CompleteAdding();    // Done with images.
                    },
                    () =>                   // Task 2: Process images serially
                    {
                        foreach (var img in images.GetConsumingEnumerable())
                        {
                            string newPath = Path.Combine(_path, String.Format("{0}_rot.png", img.Tag));
                            Console.WriteLine("Rotating image {0}", img.Tag);
                            img.RotateFlip(RotateFlipType.RotateNoneFlipXY);
    
                            img.Save(newPath);
                        }
                    });
            }
    
            public Image RetrieveImages(string url, int i)
            {
                using (WebClient client = new WebClient())
                {
                    string fileName = Path.Combine(_path, String.Format("{0}.png", i));
                    Console.WriteLine("Downloading {0}...", url);
                    client.DownloadFile(url, Path.Combine(_path, fileName));
                    Console.WriteLine("Saving {0} as {1}.", url, fileName);
                    return Image.FromFile(Path.Combine(_path, fileName));
                }
            } 
        }
    }
