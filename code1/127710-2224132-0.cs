    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <cs>
      <PictureBox Content=""Qk1mAgAAAAAAALYAAAAoAAAAFgAAABIAAAABAAgAAAAAAAAAAADEDgAAxA4AACAAAAAgAAAA/////8z///8z////AMD////MzP9mzMz/M8zM/zOZzP/AwMD/vLy8/2aZmf8zmZn/M2aZ/5CQkP9sbGz/ZmZm/zMzZv9BQUH/AAAA/8DAwAAAAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8TEw0PDw8PDRMTExMTExMTExMTExMTAAATDw8JCQkJEQ0TExAQEBAQEBMTExMTAAAODQAPCQEJCRENEAUFBQUFBRAQExMTAAAOAQ8NDwkBAAkRAwMCAgICBQULEBMTAAANDw0ADw0NAAkRAwICAgICAgUFCxATAAATDwEPDw8JAAkRAwICAgUFBQIFBRATAAATDQ8PCQEAEREDAwICAgICAgICBQsQAAATExMPDw8PEQMDAgcHBwsLCwwMBQsQAAATEw8BAA8BABEDAgcCAgICAgIFDAsQAAATEw8BDxMPAREDAwIFBQUFBQUFBQsQAAATDwEADxMPAQARAwICAgIKCgYEBAsQAAATDwEPExMQDwERAwIGBAQCBgASAAsQAAATDQ8NExMTDRENAgIGEgACAgYAABATAAATExMTExMTEAMDAgIAAAACAgYKChATAAATExMTExMTExADAwIKBgYCAgIGEBMTAAATExMTExMTExMQEAMCCgoCAhAQExMTAAATExMTExMTExMTExAQEBAQEBMTExMTAAATExMTExMTExMTExMTExMTExMTExMTAAA="" LocationX=""446"" LocationY=""125"" />
    </cs>";
            var x = XDocument.Parse(xml);
            var s = x.Descendants("PictureBox").First().Attribute("Content").Value;
            var f = new Form();
            PictureBox p = new PictureBox();
            p.Dock = DockStyle.Fill;
            f.Controls.Add(p);
            p.Image = Base64ToImage(s);
            Application.Run(f);
        }
    
        static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes);
            return Image.FromStream(ms, true);
        }
    }
