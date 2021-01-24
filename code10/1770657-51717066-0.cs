    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const int TOTAL_BUTTONS = 61;
            const int BUTTON_SIZE = 40;
            const int SPACE = 10;
            public Form1()
            {
                InitializeComponent();
                BuildMatrix();
            }
            public enum LOCATION
            {
                TOP_ROW,
                LEFT_BUTTON,
                RIGHT_BUTTON,
                BOTTOM_ROW
            }
            List<List<Button>> matrix = new List<List<Button>>();
            int numberButtons = 0;
            public void BuildMatrix()
            {
                int centerX = 0;
                int centerY = 0;
                int loopCounter = 1; //count of number of loops around matrix  
                int numberRows = 0;
                int rowCount = 0;
                int columnCount = 0;
                centerX = this.Width / 2;
                centerY = this.Height / 2;
                LOCATION location = LOCATION.TOP_ROW;
                List<Button> newRow = new List<Button>();
                Button newButton = null;
                Button buttonLeft = null;
                for (int buttonCount = 0; buttonCount < TOTAL_BUTTONS; buttonCount++)
                {
                    switch (location)
                    {
                        case LOCATION.TOP_ROW :
                            if (columnCount == 0)
                            {
                                newRow = new List<Button>();
                                if (numberRows++ == 0)
                                {
                                    matrix.Add(newRow);
                                    newButton = AddButton(centerY - (BUTTON_SIZE / 2), centerX - (BUTTON_SIZE / 2));
                                    //add first button
                                    newRow.Add(newButton);
                                    loopCounter++;
                                    continue;
                                }
                                else
                                {
                                    matrix.Insert(0, newRow);
                                    Button buttonDownRight = matrix[1][columnCount];
                                    newButton = AddButton(buttonDownRight.Top - SPACE - BUTTON_SIZE, buttonDownRight.Left - ((SPACE + BUTTON_SIZE) / 2));
                                }
                            }
                            else
                            {
                                buttonLeft = matrix[rowCount][columnCount - 1];
                                newButton = AddButton(buttonLeft.Top, buttonLeft.Left + SPACE + BUTTON_SIZE);
                            }
                            //put new button above button below, move up one row, move left half column
                            newRow.Add(newButton);
                            if (++columnCount == loopCounter)
                            {
                                location = LOCATION.LEFT_BUTTON;
                                rowCount++;
                            }
                            break;
                        case LOCATION.LEFT_BUTTON :
                            Button buttonRight = matrix[rowCount][0];
                            newButton = AddButton(buttonRight.Top, buttonRight.Left - SPACE - BUTTON_SIZE);
                            matrix[rowCount].Insert(0, newButton);
                            location = LOCATION.RIGHT_BUTTON;
                            break;
                        case LOCATION.RIGHT_BUTTON :
                            buttonLeft = matrix[rowCount][matrix[rowCount].Count - 1];
                            newButton = AddButton(buttonLeft.Top, buttonLeft.Left + SPACE + BUTTON_SIZE);
                            matrix[rowCount].Add(newButton);
                            rowCount++;
                            if (rowCount >= numberRows)
                            {
                                location = LOCATION.BOTTOM_ROW;
                            }
                            else
                            {
                                location = LOCATION.LEFT_BUTTON;
                            }
                            columnCount = 0;
                            break;
                        case LOCATION.BOTTOM_ROW :
                            if (columnCount == 0)
                            {
                                newRow = new List<Button>();
                                matrix.Add(newRow);
                                numberRows++;
                            }
                            Button buttonTopLeft = matrix[rowCount - 1][columnCount];
                            newButton = AddButton(buttonTopLeft.Top + SPACE + BUTTON_SIZE, buttonTopLeft.Left + ((SPACE + BUTTON_SIZE) / 2));
                            matrix[rowCount].Add(newButton);
                            if (++columnCount == loopCounter)
                            {
                                location = LOCATION.TOP_ROW;
                                columnCount = 0;
                                rowCount = 0;
                                loopCounter++;
                            }
                           
                            break;
                    }
                }
                
            }
            public Button AddButton(int top, int left)
            {
                Button newButton = new Button();
                newButton.Width = BUTTON_SIZE;
                newButton.Height = BUTTON_SIZE;
                newButton.Top = top ;
                newButton.Left = left;
                numberButtons++;
                newButton.Text = numberButtons.ToString();
                this.Controls.Add(newButton);
                return newButton;
            }
        }
    }
