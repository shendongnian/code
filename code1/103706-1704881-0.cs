    using System.Text;
    using System.IO;
    static void Main(string[] args)
    {
      // replace string with your file path and name file.
      using (StreamWriter sw = new StreamWriter("line.txt"))
      {
        sw.WriteLine(MyTextBox.Text);
      }
    }
