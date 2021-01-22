using SFML;
using SFML.Window;
using SFML.Graphics;
public void Main()
{
    var output = new RenderWindow(new VideoMode(640, 480), "SFML.NET Text Example");
    var exampleText = new String2D("", new Font("myfont.tff"));
    exampleText.Position = new Vector2(5, 5);
    while(true)
    {
        var timestamp = DateTime.Now.ToString("hh:MM.ss");
        output.Clear(new SFML.Graphics.Color(0, 128, 160));
        exampleText.Text = $"Hello, world! {timestamp}";
        output.Draw(exampleText);
        output.Display();
    }
}
SFML.NET 2.x
using SFML;
using SFML.Window;
using SFML.Graphics;
public void Main()
{
    var output = new RenderWindow(new VideoMode(640, 480), "SFML.NET Text Example");
    var exampleText = new Text("", new Font("myfont.tff"));
    exampleText.Position = new Vector2(5, 5);
    while(true)
    {
        var timestamp = DateTime.Now.ToString("hh:MM.ss");
        output.Clear(new SFML.Graphics.Color(0, 128, 160));
        exampleText.DisplayedString = $"Hello, world! {timestamp}";
        output.Draw(exampleText);
        output.Display();
    }
}
Obviously a very stripped back example but hopefully demonstrates just how simple the difference is.
