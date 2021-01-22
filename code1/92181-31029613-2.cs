                var sketchFolder = Regex.Replace(some_image, @"(\d{4})(\d{2})(\d{4})", @"c:\Sketches\$1\$2\$3\_BLD");
                var sketchHref = Regex.Replace(some_image, @"(\d{4})(\d{2})(\d{4})", @"/sketches/$1/$2/$3/_BLD");
                Int16 i = 0;
                if (System.IO.Directory.Exists(sketchFolder))
                {
                    List<string> gifs = GetGifs(sketchFolder);
                    gifs.ForEach(delegate(String gif)
                    {
                        string s = sketchHref + "/" + gif;
                        string f = sketchFolder + "/" + gif;
                        if (System.IO.File.Exists(f))
                        {
                            Sketches sketch = new Sketches(s, (++i).ToString(), gif);
                            hrefs.Add(sketch);
                        }
                        else // gif does not exist
                        {
                            Sketches sketch = new Sketches("placeholder.png", (++i).ToString(), gif);
                            hrefs.Add(sketch);
                        }
                    });
                }
                else // folder does not exist
                {
                    Sketches sketch = new Sketches("placeholder.png", (++i).ToString(), "");
                    hrefs.Add(sketch);
                }
                return hrefs;
            }
        }
    public class Sketches : Tuple<string, string, string>
    {
        public Sketches(string SketchHref, string SketchNumber, string SketchName) : base(SketchHref, SketchNumber, SketchName) { }
        public string SketchHref { get { return this.Item1; } }
        public string SketchNumber { get { return this.Item2; } }
        public string SketchName { get { return this.Item3; } }
    }
