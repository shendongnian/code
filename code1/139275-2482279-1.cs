    public enum MyChoices
    {
        Choice1,
        Choice2,
        Choice3
    }
    
    public partial class Form1 : Form
    {
        private Dictionary<int, RadioButton> radButtons;
        private MyChoices choices;
    
        public Form1()
        {
            this.InitializeComponent();
            this.radButtons = new Dictionary<int, RadioButton>();
            this.radButtons.Add(0, this.radioButton1);
            this.radButtons.Add(1, this.radioButton2);
            this.radButtons.Add(2, this.radioButton3);
    
            foreach (var item in this.radButtons)
            {
                item.Value.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
            }
        }
    
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            foreach (var item in this.radButtons)
            {
                if (item.Value == button)
                {
                    this.choices = (MyChoices)item.Key;
                }
            }
        }
    
        public MyChoices Choices
        {
            get { return this.choices; }
            set
            {
                this.choices = value;
                this.SelectRadioButton(value);
                this.OnPropertyChanged(new PropertyChangedEventArgs("Choices"));
            }
        }
    
        private void SelectRadioButton(MyChoices choiceID)
        {
            RadioButton button;
            this.radButtons.TryGetValue((int)choiceID, out button);
            button.Checked = true;
        }
    }
