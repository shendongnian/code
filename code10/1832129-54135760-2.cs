    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<Flashcard> flashcards;
        private int nextRecord;
        // Use a valid path on your system here (the file doesn't need to exist)
        private const string FilePath = @"f:\public\temp\temp.csv";
        private void LoadFlashcards()
        {
            flashcards = Engine.ReadFile(FilePath);
            nextRecord = 0;
        }
        public void DisplayNextFlashcard()
        {
            if (flashcards == null)
            {
                LoadFlashcards();
            }
            else if (nextRecord >= flashcards.Count)
            {
                // Do something when all records have been read
                nextRecord = 0;
            }
            var flashcard = flashcards[nextRecord++];
            lblQuestion.Text = flashcard.Question;
            lblAnswer.Visible = false;
            lblAnswer.Text = flashcard.Answer;
            
            Image.Visible = flashcard.Image;
            Image.Image = Properties.Resources.FlashcardImage;
        }
        private void btn_NextFlashcard_Click(object sender, EventArgs e)
        {
            DisplayNextFlashcard();
        }
    }
    class Flashcard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Image { get; set; }
        public static Flashcard Parse(string csvLine)
        {
            if (csvLine == null) throw new ArgumentNullException(nameof(csvLine));
            var parts = csvLine.Split(',').Select(item => item.Trim()).ToList();
            if (parts.Count != 3) throw new FormatException(
                "csvLine does not contain 3 comma-separated items.");
            return new Flashcard
            {
                Question = parts[0],
                Answer = parts[1],
                Image = !parts[2].Equals("FALSE", StringComparison.OrdinalIgnoreCase)
            };
        }
    }
    class Engine
    {
        public static List<Flashcard> ReadFile(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) CreateFile(filePath);
            return File.ReadAllLines(filePath).Select(Flashcard.Parse).ToList();
        }
        private static void CreateFile(string filePath)
        {
            File.CreateText(filePath).Close();
            File.WriteAllText(filePath, @"What is more useful when it is broken?, An egg, TRUE
