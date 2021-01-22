    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;    
    public class CSVReader
    {
        private const string ESCAPE_SPLIT_REGEX = "({1}[^{1}]*{1})*(?<Separator>{0})({1}[^{1}]*{1})*";
        private string[] FieldNames;
        private List<string[]> Records;
        private int ReadIndex;
    
        public CSVReader(string File)
        {
            Records = new List<string[]>();
            string[] Record = null;
            StreamReader Reader = new StreamReader(File);
            int Index = 0;
            bool BlankRecord = true;
    
            FieldNames = GetEscapedSVs(Reader.ReadLine());
            while (!Reader.EndOfStream)
            {
                Record = GetEscapedSVs(Reader.ReadLine());
                BlankRecord = true;
                for (Index = 0; Index <= Record.Length - 1; Index++)
                {
                    if (!string.IsNullOrEmpty(Record[Index])) BlankRecord = false;
                }
                if (!BlankRecord) Records.Add(Record);
            }
            ReadIndex = -1;
            Reader.Close();
        }
    
        private string[] GetEscapedSVs(string Data)
        {
            return GetEscapedSVs(Data, ",", "\"");
        }
        private string[] GetEscapedSVs(string Data, string Separator, string Escape)
        {
            string[] Result = null;
            int Index = 0;
            int PriorMatchIndex = 0;
            MatchCollection Matches = Regex.Matches(Data, string.Format(ESCAPE_SPLIT_REGEX, Separator, Escape));
    
            Result = new string[Matches.Count];
    
    
            for (Index = 0; Index <= Result.Length - 2; Index++)
            {
                Result[Index] = Data.Substring(PriorMatchIndex, Matches[Index].Groups["Separator"].Index - PriorMatchIndex);
                PriorMatchIndex = Matches[Index].Groups["Separator"].Index + Separator.Length;
            }
            Result[Result.Length - 1] = Data.Substring(PriorMatchIndex);
    
            for (Index = 0; Index <= Result.Length - 1; Index++)
            {
                if (Regex.IsMatch(Result[Index], string.Format("^{0}[^{0}].*[^{0}]{0}$", Escape))) Result[Index] = Result[Index].Substring(1, Result[Index].Length - 2);
                Result[Index] = Result[Index].Replace(Escape + Escape, Escape);
                if (Result[Index] == null) Result[Index] = "";
            }
    
            return Result;
        }
    
        public int FieldCount
        {
            get { return FieldNames.Length; }
        }
    
        public string GetString(int Index)
        {
            return Records[ReadIndex][Index];
        }
    
        public string GetName(int Index)
        {
            return FieldNames[Index];
        }
    
        public bool Read()
        {
            ReadIndex = ReadIndex + 1;
            return ReadIndex < Records.Count;
        }
    
    
        public void DisplayResults(DataGridView DataView)
        {
            DataGridViewColumn col = default(DataGridViewColumn);
            DataGridViewRow row = default(DataGridViewRow);
            DataGridViewCell cell = default(DataGridViewCell);
            DataGridViewColumnHeaderCell header = default(DataGridViewColumnHeaderCell);
            int Index = 0;
            ReadIndex = -1;
    
            DataView.Rows.Clear();
            DataView.Columns.Clear();
    
            for (Index = 0; Index <= FieldCount - 1; Index++)
            {
                col = new DataGridViewColumn();
                col.CellTemplate = new DataGridViewTextBoxCell();
                header = new DataGridViewColumnHeaderCell();
                header.Value = GetName(Index);
                col.HeaderCell = header;
                DataView.Columns.Add(col);
            }
    
            while (Read())
            {
                row = new DataGridViewRow();
                for (Index = 0; Index <= FieldCount - 1; Index++)
                {
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = GetString(Index).ToString();
                    row.Cells.Add(cell);
                }
                DataView.Rows.Add(row);
            }
        }
    }
