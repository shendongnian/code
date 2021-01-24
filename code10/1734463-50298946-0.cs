    public partial class MainWindow : Window
    {
        private int MaxAttempts = 4;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMotPropose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmatBoxResult = System.Windows.MessageBox.Show(
                "Êtes-vous sûr ?", "Confirmer", System.Windows.MessageBoxButton.YesNo);
            var lookupLetters = new Dictionary<char, List<Label>>();
            if (confirmatBoxResult == MessageBoxResult.Yes)
            {
                int attemptCounter = 0;
                for (char c = 'a'; c <= 'z'; c++)
                {
                    char ch = c;
                    Button btn = new Button();
                    btn.Content = c;
                    btn.Width = 60;
                    btn.Height = 60;
                    btn.FontSize = 36;
                    panel_lettre.Children.Add(btn);
                    lookupLetters[ch] = new List<Label>();
                    btn.Click += new RoutedEventHandler(btnLetter_Click);
                    void btnLetter_Click(object sender2, RoutedEventArgs e2)
                    {
                        if (lookupLetters.TryGetValue(ch, out List<Label> textList))
                        {
                            attemptCounter++;
                            foreach (var el in textList)
                            {
                                el.Content = ch;
                                btn.IsEnabled = false;
                            }
                            if (!textList.Any())
                            {
                                btn.IsEnabled = false;
                                MessageBox.Show("Wrong letter!");
                            }
                            if (attemptCounter == MaxAttempts)
                            {
                                MessageBox.Show("Max attempts reached!");
                                ShowAnswer(lookupLetters);
                            }
                            if (AreAllLettersUncovered())
                            {
                                MessageBox.Show("Well done, you've found the word !!");
                            }
                        }
                    }
                }
                foreach (char ch in txtMot.Text)
                {
                    Label Lbl = new Label();                    
                    Lbl.Content = "_";
                    Lbl.FontSize = 36;
                    Lbl.Width = 30;
                    lookupLetters[ch].Add(Lbl);
                    panel_label.Children.Add(Lbl);
                }
                btnMotPropose.IsEnabled = false;
            }
        }
        private bool AreAllLettersUncovered()
        {
            return panel_label.Children.Cast<Label>().All(p => (string)p.Content != "_");
        }
        private void ShowAnswer(Dictionary<char, List<Label>> lookupLetters)
        {
            var lettersWithLabels = lookupLetters.Where(p => p.Value.Any());
            foreach (var letterWithLabel in lettersWithLabels)
            {
                foreach (var label in letterWithLabel.Value)
                {
                    label.Content = letterWithLabel.Key.ToString();
                }
            }
        }
    }
