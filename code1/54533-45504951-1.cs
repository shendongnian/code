    using YourProject.Properties;
    using System;
    using System.Linq;
    using System.Windows;
    using System.Xml.Linq;
    namespace YourProject.Extensions
    {
        public static class WindowExtensions
        {
            public static void SaveSizeAndLocation(this Window w)
            {
                try
                {
                    var s = "<W>";
                    s += GetNode("Top", w.WindowState == WindowState.Maximized ? w.RestoreBounds.Top : w.Top);
                    s += GetNode("Left", w.WindowState == WindowState.Maximized ? w.RestoreBounds.Left : w.Left);
                    s += GetNode("Height", w.WindowState == WindowState.Maximized ? w.RestoreBounds.Height : w.Height);
                    s += GetNode("Width", w.WindowState == WindowState.Maximized ? w.RestoreBounds.Width : w.Width);
                    s += GetNode("WindowState", w.WindowState);
                    s += "</W>";
                    Settings.Default.WindowXml = s;
                    Settings.Default.Save();
                }
                catch (Exception)
                {
                }
            }
            public static void RestoreSizeAndLocation(this Window w)
            {
                try
                {
                    var xd = XDocument.Parse(Settings.Default.WindowXml);
                    w.WindowState = (WindowState)Enum.Parse(typeof(WindowState), xd.Descendants("WindowState").FirstOrDefault().Value);
                    w.Top = Convert.ToDouble(xd.Descendants("Top").FirstOrDefault().Value);
                    w.Left = Convert.ToDouble(xd.Descendants("Left").FirstOrDefault().Value);
                    w.Height = Convert.ToDouble(xd.Descendants("Height").FirstOrDefault().Value);
                    w.Width = Convert.ToDouble(xd.Descendants("Width").FirstOrDefault().Value);
                }
                catch (Exception)
                {
                }
            }
            private static string GetNode(string name, object value)
            {
                return string.Format("<{0}>{1}</{0}>", name, value);
            }
        }
    }
