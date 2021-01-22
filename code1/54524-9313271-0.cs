    public class WindowStateHelper
    {
        public static string ToXml(System.Windows.Window win)
        {
            XElement bounds = new XElement("Bounds");
            if (win.WindowState == System.Windows.WindowState.Maximized)
            {
                bounds.Add(new XElement("Top", win.RestoreBounds.Top));
                bounds.Add(new XElement("Left", win.RestoreBounds.Left));
                bounds.Add(new XElement("Height", win.RestoreBounds.Height));
                bounds.Add(new XElement("Width", win.RestoreBounds.Width));
            }
            else
            {
                bounds.Add(new XElement("Top", win.Top));
                bounds.Add(new XElement("Left", win.Left));
                bounds.Add(new XElement("Height", win.Height));
                bounds.Add(new XElement("Width", win.Width));
            }
            XElement root = new XElement("WindowState",
                new XElement("State", win.WindowState.ToString()),
                new XElement("Visibility", win.Visibility.ToString()),
                bounds);
            return root.ToString();
        }
        public static void FromXml(string xml, System.Windows.Window win)
        {
            try
            {
                XElement root = XElement.Parse(xml);
                string state = root.Descendants("State").FirstOrDefault().Value;
                win.WindowState = (System.Windows.WindowState)Enum.Parse(typeof(System.Windows.WindowState), state);
                state = root.Descendants("Visibility").FirstOrDefault().Value;
                win.Visibility = (System.Windows.Visibility)Enum.Parse(typeof(System.Windows.Visibility), state);
                XElement bounds = root.Descendants("Bounds").FirstOrDefault();
                win.Top = Convert.ToDouble(bounds.Element("Top").Value);
                win.Left = Convert.ToDouble(bounds.Element("Left").Value);
                win.Height = Convert.ToDouble(bounds.Element("Height").Value);
                win.Width = Convert.ToDouble(bounds.Element("Width").Value);
            }
            catch (Exception x)
            {
                System.Console.WriteLine(x.ToString());
            }
        }
    }
