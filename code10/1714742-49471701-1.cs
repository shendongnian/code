    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Distance_Converter
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void ConvertButton_click(object sender, EventArgs e)
            {
                int distance_to_convert;
                string lengthOption1;
                string lengthOption2;
                int feet = 12; 
                lengthOption1 = FromListBox.SelectedItem.ToString();    
                distance_to_convert = int.Parse(distancetoconvertTextBox.Text);
    
                if ((FromListBox.SelectedIndex) != 1 && (ToListBox.SelectedIndex) != -1)
    
                    lengthOption1 = FromListBox.SelectedItem.ToString();
                    lengthOption2 = ToListBox.SelectedItem.ToString();
                {
                    switch (lengthOption1)
                    {
                        case "Inches":
                            if (lengthOption2 == "Inches")
                            {
                                ConvertedDistanceTextBox.Text = distance_to_convert.ToString();
                            }
                            else if (lengthOption2 == "Feet")
                            {
                                double inches_feet = (double)distance_to_convert / feet;
                                //int feet = 12; 
                                ConvertedDistanceTextBox.Text = inches_feet.ToString();
                            }
                            else if (lengthOption2 == "Yards")
                            {
                                double inches_yard = (double)distance_to_convert / 36;
                                ConvertedDistanceTextBox.Text = inches_yard.ToString();
                            }
                            break;
                        case "Feet":
                            if (lengthOption2 == "Inches")
                            {
                                double feet_inches = (double)distance_to_convert * 12;
                                ConvertedDistanceTextBox.Text = feet_inches.ToString();
                            }
                            else if (lengthOption2 == "Feet")
                            {
                                ConvertedDistanceTextBox.Text = distance_to_convert.ToString(); ;
                            }
                            else if (lengthOption2 == "Yards")
                            {
                                float  feet_yard =(float) distance_to_convert / 3;
                                ConvertedDistanceTextBox.Text = feet_yard.ToString();
                            }
                            break;
    
                        case "Yards":
                            if (lengthOption2 == "Inches")
                            {
                                double Yards_inches = (double)distance_to_convert * 36;
                                ConvertedDistanceTextBox.Text = Yards_inches.ToString();
                            }
                            else if (lengthOption2 == "Feet")
                            {
                                double Yards_feet = (double) distance_to_convert * 3;
                                ConvertedDistanceTextBox.Text = Yards_feet.ToString();
                            }
                            else if (lengthOption2 == "Yards")
                            {
                                ConvertedDistanceTextBox.Text = distance_to_convert.ToString(); ;
                            }
                            break;
                    }
                }
    
            }
            private void Exitbutton_click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }
