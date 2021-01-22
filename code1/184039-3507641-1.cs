    using Microsoft.Win32;
    using System.Collections.Generic;
    lv.ItemsSource = null;
    List<XmlElement> elements = new List<XmlElement>();
    Microsoft.Win32.FileDialog fd = new Microsoft.Win32.OpenFileDialog();
    bool ?a = fd.ShowDialog();
    if (a == true)
    {
         XmlDocument doc = new XmlDocument();
         string dir = fd.FileName.Remove(fd.FileName.Length - fd.SafeFileName.Length, fd.SafeFileName.Length);
         string[] files = Directory.GetFiles(dir);
         foreach (string file in files)
         {
               XmlElement item = doc.CreateElement(file.Remove(0,dir.Length));
               item.SetAttribute("Name", file.Remove(0, dir.Length));
               item.SetAttribute("Type", Path.GetExtension(file));
               item.SetAttribute("Image", "images\\cat.png");
               elements.Add(item);
          }
    }
    lv.ItemsSource = elements;
