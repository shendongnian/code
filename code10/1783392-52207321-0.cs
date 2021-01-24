    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Sudoku
    {
        public partial class Form1 : Form
        {
            SUDOKU sudoku = null;
            public Form1()
            {
                InitializeComponent();
                sudoku =  new SUDOKU(this);
            }
            private void Solve_Click(object sender, EventArgs e)
            {
                SUDOKU.Solve();
            }
            private void Clear_Click(object sender, EventArgs e)
            {
                this.Controls.Remove(sudoku);
                sudoku.Dispose();
                sudoku = new SUDOKU(this);
            }
        }
        public class SUDOKU : Panel
        {
            public const int TOP_MARGIN = 50;
            public const int LEFT_MARGIN = 50;
            static List<Cell> cells = new List<Cell>();
            static List<List<Cell>> rows = null;
            static List<List<Cell>> columns = null;
            static List<List<Cell>> boxes = null;
            public SUDOKU(Form form)
            {
                form.Controls.Add(this);
                this.Left = LEFT_MARGIN;
                this.Top = TOP_MARGIN;
                this.Width = (2 * LEFT_MARGIN) + (9 * Cell.WIDTH);
                this.Height = (2 * TOP_MARGIN) + (9 * Cell.HEIGHT);
                rows = (new string('\0',9)).Select(x => new List<Cell>()).ToList();
                columns = (new string('\0', 9)).Select(x => new List<Cell>()).ToList();
                boxes = (new string('\0', 9)).Select(x => new List<Cell>()).ToList();
                for (int i = 0; i < 81; i++)
                {
                    Cell newCell = new Cell(i);
                    this.Controls.Add(newCell);
                }
            }
            public static void Solve()
            {
                for (int i = 0; i < 81; i++)
                {
                    if (cells[i].textBox.Text != "")
                    {
                        cells[i].value = int.Parse(cells[i].textBox.Text);
                    }
                }
                RecursiveSolve(0);
            }
            static Boolean RecursiveSolve(int index)
            {
                Boolean solved = false;
                Cell cell = cells[index];
                if (cell.value != null)
                {
                    if (index == 80)
                    {
                        solved = true;
                    }
                    else
                    {
                        solved = RecursiveSolve(index + 1);
                    }
                }
                else
                {
                    for (int i = 1; i <= 9; i++)
                    {
                        if (!rows[cell.row].Where(x => x.value == i).Any())
                        {
                            if (!columns[cell.column].Where(x => x.value == i).Any())
                            {
                                if (!boxes[cell.box].Where(x => x.value == i).Any())
                                {
                                    cell.value = i;
                                    cell.textBox.Text = i.ToString();
                                    cell.textBox.SelectionAlignment = HorizontalAlignment.Center;
                                    cell.textBox.SelectionFont = new Font("Ariel", 30);
                                    if (index == 80)
                                    {
                                        solved = true;
                                    }
                                    else
                                    {
                                        solved = RecursiveSolve(index + 1);
                                        if (solved)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            cell.value = null;
                                            cell.textBox.Text = "";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return solved;
            }
            public class Cell : Panel
            {
                public const int WIDTH = 100;
                public const int HEIGHT = 100;
                public Dictionary<int, int> boxDict = new Dictionary<int, int>() {
                    {0,0}, {1,0},{2,0},{3,1},{4,1},{5,1},{6,2},{7,2},{8,2},
                    {9,0}, {10,0},{11,0},{ 12,1},{13,1},{14,1},{15,2},{16,2},{17,2},
                    {18,0}, {19,0},{20,0},{21,1},{22,1},{23,1},{24,2},{25,2},{26,2},
                    {27,3}, {28,3},{29,3},{30,4},{31,4},{32,4},{33,5},{34,5},{35,5},
                    {36,3}, {37,3},{38,3},{39,4},{40,4},{41,4},{42,5},{43,5},{44,5},
                    {45,3}, {46,3},{47,3},{48,4},{49,4},{50,4},{51,5},{52,5},{53,5},
                    {54,6}, {55,6},{56,6},{57,7},{58,7},{59,7},{60,8},{61,8},{62,8},
                    {63,6}, {64,6},{65,6},{66,7},{67,7},{68,7},{69,8},{70,8},{71,8},
                    {72,6}, {73,6},{74,6},{75,7},{76,7},{77,7},{78,8},{79,8},{80,8},
                };
                public int index = 0;
                public int row = 0;
                public int column = 0;
                public int box = 0;
                public int? value = null;
                public RichTextBox textBox = new RichTextBox();
                public Cell() { }
                public Cell(int index)
                {
                    cells.Add(this);
                    this.index = index;
                    this.row = index / 9;
                    this.column = index % 9;
                    this.box = boxDict[index];
                    this.Left = SUDOKU.LEFT_MARGIN + (column * WIDTH);
                    this.Top = SUDOKU.TOP_MARGIN + (row * HEIGHT);
                    this.Width = WIDTH;
                    this.Height = HEIGHT;
                    this.Controls.Add(textBox);
                    textBox.Left = 0;
                    textBox.Top = 0;
                    textBox.Width = WIDTH;
                    textBox.Height = HEIGHT;
                    textBox.SelectionAlignment = HorizontalAlignment.Center;
                    textBox.SelectionFont = new Font("Ariel", 30);
                    //textBox.Text = index.ToString();
                    textBox.Multiline = false;
                    rows[row].Add(this);
                    columns[column].Add(this);
                    boxes[box].Add(this);
                }
            }
            public void Dispose()
            {
                cells = new List<Cell>(); 
                rows = new List<List<Cell>>();
                columns = new List<List<Cell>>(); ;
                boxes = new List<List<Cell>>();
            }
        }
    }
