    public partial class Form1 : Form
    {
        //set these variables appropriately
        int matrixWidth = 96;
        int matrixHeight = 16;
        //An array to hold which LEDs must be lit
        bool[,] ledMatrix = null;
        //Used to randomly populate the LED array
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            ledPanel.BackColor = Color.Black;
            ledPanel.Resize += LedPanel_Resize;
            //clear the array by initializing a new one
            ledMatrix = new bool[matrixWidth, matrixHeight];
            //Force the panel to repaint itself
            ledPanel.Invalidate();
        }
        private void LedPanel_Resize(object sender, EventArgs e)
        {
            //If the panel resizes, then repaint.  
            ledPanel.Invalidate();
        }
        List<Form> forms = new List<Form>();
        private void button1_Click(object sender, EventArgs e)
        {
            //clear the array by initializing a new one
            ledMatrix = new bool[matrixWidth, matrixHeight];
            //Randomly set 250 of the 'LEDs';
            for (int i = 0; i < 250; i++)
            {
                ledMatrix[rnd.Next(0, matrixWidth), rnd.Next(0, matrixHeight)] = true;
            }
            //Make the panel repaint itself
            ledPanel.Invalidate();
        }
        private void ledPanel_Paint(object sender, PaintEventArgs e)
        {
            //Calculate the width and height of each LED based on the panel width
            //and height and allowing for a line between each LED
            int cellWidth = (ledPanel.Width - 1) / (matrixWidth + 1);
            int cellHeight = (ledPanel.Height - 1) / (matrixHeight + 1);
            //Loop through the boolean array and draw a filled rectangle
            //for each one that is set to true
            for (int i = 0; i < matrixWidth; i++)
            {
                for (int j = 0; j < matrixHeight; j++)
                {
                    if (ledMatrix != null)
                    {
                        //I created a custom brush here for the 'off' LEDs because none
                        //of the built in colors were dark enough for me. I created it
                        //in a using block because custom brushes need to be disposed.
                        using (var b = new SolidBrush(Color.FromArgb(64, 0, 0)))
                        {
                            //Determine which brush to use depending on if the LED is lit
                            Brush ledBrush = ledMatrix[i, j] ? Brushes.Red : b;
                            //Calculate the top left corner of the rectangle to draw
                            var x = (i * (cellWidth + 1)) + 1;
                            var y = (j * (cellHeight + 1) + 1);
                            //Draw a filled rectangle
                            e.Graphics.FillRectangle(ledBrush, x, y, cellWidth, cellHeight);
                        }
                    }
                }
            }
        }
    }
