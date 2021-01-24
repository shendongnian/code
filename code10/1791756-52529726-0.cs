    void Main()
    {
        CreateExampleObject("testing");
    }
    
    public class Example
    {
        // This is a constructor that requires a string as an argument
        public Example(string text)
        {
            this.Text = text;
        }
        
        public string Text { get; set; }
    }
    
    public void CreateExampleObject(string text)
    {
        Example example = new Example(text);
        
        Console.WriteLine(example.Text);
    }
