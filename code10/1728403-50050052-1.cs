    namespace Random_Card
    {&#xD;
        public partial class Form1 : Form
        {
            private Random rand = new Random();
            public Form1()
            {
                InitializeComponent();
            }
    
            private void getCardButton_Click(object sender, EventArgs e)
            {
                // Get five unique random indexes
                List<int> shuffledIndexes = Enumerable.Range(0, cardImageList.Images.Count)
                    .OrderBy(x => rand.NextDouble()).Take(5).ToList();   
    
                cardPictureBox.Image = cardImageList.Images[shuffledIndexes[0]];
                cardPictureBox1.Image = cardImageList.Images[shuffledIndexes[1]];
                cardPictureBox2.Image = cardImageList.Images[shuffledIndexes[2]];
                cardPictureBox3.Image = cardImageList.Images[shuffledIndexes[3]];
                cardPictureBox4.Image = cardImageList.Images[shuffledIndexes[4]];          
            }
        }
    }
