    using System;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                String[] arr = new String[3];
                arr[0] = "B";
                arr[1] = "C";
                arr[2] = "A";
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                Console.WriteLine(arr[2]);
                Sort(arr);
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                Console.WriteLine(arr[2]);
                // Write to file
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Test\Result.txt"))
                {
                    foreach (string str in arr)
                    {
                        file.WriteLine(str);
                    }
                }
            }
            public void Sort(String[] arr)
            {
                String temp = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i].CompareTo(arr[j]) > 0)
                        {
                            temp = arr[j];
                            arr[j] = arr[i];
                            arr[i] = temp;
                        }
                    }
                    //Console.WriteLine(arr[i]);
                }
            }
        }
    }
