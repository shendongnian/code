var fontSettings = System.IO.File.ReadAllLines("fontsettings.txt");
int color = int.Parse(fontSettings[0], System.Globalization.NumberStyles.Any);
string family = fontSettings[1];
float size = float.Parse(fontSettings[2], System.Globalization.CultureInfo.InvariantCulture);
FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), fontSettings[3]);
label1.ForeColor = Color.FromArgb(color);
label1.Font = new Font(family, size, style);
