    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                BattleGrid grid = new BattleGrid();
                grid.PrintGrid();
                Console.ReadLine();
            }
        }
        public class BattleGrid
        {
            public List<List<BattleGridCell>> grid = new List<List<BattleGridCell>>();
            public BattleGrid()
            {
                for (int row = 0; row < 4; row++)
                {
                    List<BattleGridCell> newRow = new List<BattleGridCell>();
                    grid.Add(newRow);
                    for (int col = 0; col < 4; col++)
                    {
                        BattleGridCell newCell = new BattleGridCell();
                        newRow.Add(newCell);
                        newCell.rowLetter = ((char)((int)'A' + row)).ToString();
                        newCell.colnumber = col.ToString();
                    }
                }
            }
            public void PrintGrid()
            {
                foreach (List<BattleGridCell> row in grid)
                {
                    Console.WriteLine("|" + string.Join("|", row.Select(x => "X" + x.rowLetter + x.colnumber))); 
                }
            }
        }
        public class BattleGridCell
        {
            public string rowLetter { get; set; }
            public string colnumber { get; set; }
        }
    }
