    namespace RandomArray
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within    a       Frame.
        /// </summary>
        public sealed partial class Arraytwenty : Page
        {
            //Declare your class array for storing integers, this will have scope in any method of your class
            private int[] arraytwenty;
            public Arraytwenty()
            {
                //initialize your array
                this.arraytwenty = new int[20];
                this.InitializeComponent();
            }
            
            public void GenArray20_Click(object sender, RoutedEventArgs e)
            {
                //Don't create a local array when you want to use it in your other class methods
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
