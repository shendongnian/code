    public class Command
    {
        public Command(String commandText)
        {
            this.CommandText = commandText;
        }
        public String CommandText { get; private set; }
        public void Send()
        {
            // Dummy implementation.
            Console.WriteLine(this.CommandText);
        }
        // Static command instances.
        public static readonly Command ProcessImage = new Command("process image");
        public static readonly Command BlurImage = new Command("apply blur effect");
        public static readonly Command SaveImagePng = new Command("save as png");
    }
