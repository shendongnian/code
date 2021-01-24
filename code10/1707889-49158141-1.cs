    namespace RandomArray
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within    a       Frame.
        /// </summary>
        public sealed partial class Arraytwenty : Page
        {
            public Arraytwenty()
            {
                this.InitializeComponent();
            }
            int[] arraytwenty = new int[20];
            public void GenArray20_Click(object sender, RoutedEventArgs e)
            {
    			// You have local initilization of array
    			// so code inside this method will load data into this array instead of global
                //int[] arraytwenty = new int[20];
                Random Number = new Random();
    
                for (int i = 0; i < 20; i++)
                {
                    int randomnum = Number.Next(1, 101);
                    arraytwenty[i] = randomnum;
    
                    Original20Array.Text = Original20Array.Text + " " + Convert.ToString(arraytwenty[i]);
                }
            }
    
            private void bubsortbtn_Click(object sender, RoutedEventArgs e)
            {
                int temp = 0;
                for (int i = 0; i < arraytwenty.Length; i++)
                {
                    for (int j = 0; j < arraytwenty.Length - 1; j++)
                    {
                        if (arraytwenty[j] > arraytwenty[j + 1])
                        {
                            temp = arraytwenty[j + 1];
                            arraytwenty[j + 1] = arraytwenty[j];
                            arraytwenty[j] = temp;
                        }
                    }
                }
                string value = " ";
                for (int i = 0; i < arraytwenty.Length; i++)
                {
                    value += arraytwenty[i].ToString() + " ";
                }
                bubblesortTextbox.Text = value;
            }
    
            private void clrArraytwenty_Click(object sender, RoutedEventArgs e)
            {
                Original20Array.Text = String.Empty;
                bubblesortTextbox.Text = String.Empty;
            }
        }
    }
