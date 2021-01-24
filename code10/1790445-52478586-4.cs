    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Data;
    namespace ConsoleApplication1
    {
        public enum DEFINE_STATE
        {
            SPECIAL = -4,  //define followed by IF
            NONE = -3,
            INVALID = -2, //Compile will give error, cannot occur
            ERROR = -1,
            DO_NOT_CARE = 0,
            START = 1,
            FOUND_IF = 2,
            FOUND_DEFINE_IN_IF = 3,
            FOUND_DEFINE_NOT_IN_IF = 4,
            FOUND_INCLUDE_IN_IF = 5,
            FOUND_ELSE = 6,
            FOUND_DEFINE_IN_ELSE = 7,
            FOUND_INCLUDE_IN_ELSE = 8,
            FOUND_INCLUDE_NOT_IN_IF = 9,
            FOUND_END_IF = 10,
            RETURN = 11,
        }
        public enum ERROR
        {
            NO_ERROR,
            DEFINE_FOLLOWED_BY_DEFINE,
            DEFINE_FOLLOWED_BY_DEFINE_OR_IF
        }
        public enum TABLE_COLUMN
        {
            STATE = 0,
            DESCRIPTION = 1,
            DEFINE,
            INCLUDE,
            IF,
            ELSE,
            END_IF,
            ERROR,
            ACTION
        }
        public enum ACTION
        {
            NONE,
            RESET_DEFINE_LINE_NUMBER,
            RESET_DEFINE_IF_LINE_NUMBER,
            RESET_DEFINE_ELSE_LINE_NUMBER,
            SET_DEFINE_LINE_NUMBER,
            SET_DEFINE_IF_LINE_NUMBER,
            SET_DEFINE_ELSE_LINE_NUMBER
        }
        public class State_Variables
        {
            public int define_Line_Number = 0;
            public int define_If_Line_Number = 0;
            public int define_Else_Line_Number = 0;
            public DEFINE_STATE state = DEFINE_STATE.START;
            public DataRow row { get; set; }
        }
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string pattern = "#include\\s+\"test.h\"";
                StreamReader reader = new StreamReader(FILENAME);
                string input = "";
                DataTable dt = new DataTable();
                dt.Columns.Add("State", typeof(int));
                dt.Columns.Add("Description", typeof(DEFINE_STATE));
                dt.Columns.Add("Next Define State", typeof(int));
                dt.Columns.Add("Next Include State", typeof(int));
                dt.Columns.Add("Next IF State", typeof(int));
                dt.Columns.Add("Next Else State", typeof(int));
                dt.Columns.Add("Next ENDIF State", typeof(int));
                dt.Columns.Add("Error Number", typeof(ERROR));
                dt.Columns.Add("Action", typeof(ACTION));
                //0 do not care
                //-1 error
                //-2 invalid
                dt.Rows.Add(new object[] { 1, DEFINE_STATE.START, 4, 0, 2, -2, -2, ERROR.NO_ERROR, ACTION.NONE });
                dt.Rows.Add(new object[] { 2, DEFINE_STATE.FOUND_IF, 3, 0, 2, 6, 10, ERROR.NO_ERROR, ACTION.NONE });
                dt.Rows.Add(new object[] { 3, DEFINE_STATE.FOUND_DEFINE_IN_IF, -1, 5, 2, 6, 10, ERROR.DEFINE_FOLLOWED_BY_DEFINE, ACTION.SET_DEFINE_IF_LINE_NUMBER });
                dt.Rows.Add(new object[] { 4, DEFINE_STATE.FOUND_DEFINE_NOT_IN_IF, -1, 9, -4, -2, -2, ERROR.DEFINE_FOLLOWED_BY_DEFINE, ACTION.SET_DEFINE_LINE_NUMBER});
                dt.Rows.Add(new object[] { 5, DEFINE_STATE.FOUND_INCLUDE_IN_IF, 3, 0, 2, 6, 10, ERROR.NO_ERROR, ACTION.RESET_DEFINE_IF_LINE_NUMBER });
                dt.Rows.Add(new object[] { 6, DEFINE_STATE.FOUND_ELSE, 7, 0, 2, -2, 10, ERROR.NO_ERROR, ACTION.NONE });
                dt.Rows.Add(new object[] { 7, DEFINE_STATE.FOUND_DEFINE_IN_ELSE, -1, 8, 2, -2, 10, ERROR.DEFINE_FOLLOWED_BY_DEFINE, ACTION.SET_DEFINE_ELSE_LINE_NUMBER});
                dt.Rows.Add(new object[] { 8, DEFINE_STATE.FOUND_INCLUDE_IN_ELSE, 7, 0, 2, -2, 10, ERROR.NO_ERROR, ACTION.RESET_DEFINE_ELSE_LINE_NUMBER });
                dt.Rows.Add(new object[] { 9, DEFINE_STATE.FOUND_INCLUDE_NOT_IN_IF, 4, 0, 2, -2, -2, ERROR.NO_ERROR, ACTION.RESET_DEFINE_LINE_NUMBER });
                dt.Rows.Add(new object[] { 10, DEFINE_STATE.FOUND_END_IF, 11, 1, 2, -2, -2, ERROR.NO_ERROR, ACTION.NONE });
                dt.Rows.Add(new object[] { 11, DEFINE_STATE.RETURN, -2, -2, 2, -2, -2, ERROR.NO_ERROR, ACTION.NONE });
                int level = 0;
                List<State_Variables> states = new List<State_Variables>();
                State_Variables newState = new State_Variables();
                states.Add(newState);
                DEFINE_STATE nextState = DEFINE_STATE.START;
                ACTION action = ACTION.NONE;
                int line_number = 0;
                while ((input = reader.ReadLine()) != null)
                {
                    line_number++;
                    input = input.Trim();
                    if(input.StartsWith("//")) continue;  //ignore comments
                    if (input.Length == 0) continue;
                    Boolean returnFromIF = false;
                    Match match = Regex.Match(input, pattern);
                    //test if end if is followed by include
                    if (states[level].state == DEFINE_STATE.FOUND_END_IF)
                    {
                        if (!match.Success)
                        {
                            int define_If_Line_Number = states[level].define_If_Line_Number;
                            int define_Else_Line_Number = states[level].define_Else_Line_Number;
                            if (define_If_Line_Number != 0)
                            {
                                Console.WriteLine("Define in IF at line {0} does not have and include", define_If_Line_Number.ToString());
                            }
                            if (define_Else_Line_Number != 0)
                            {
                                Console.WriteLine("Define in ELSE at line {0} does not have and include", define_Else_Line_Number.ToString());
                            }
                        }
                        returnFromIF = true;
                        states.RemoveAt(level--);
                    }
                    else
                    {
                        states[level].row = dt.AsEnumerable().Where(x => x.Field<int>((int)TABLE_COLUMN.STATE) == (int)states[level].state).FirstOrDefault();
                    }
                    nextState = DEFINE_STATE.NONE;
                    //check if defines are terminated with include
                    if (input.Contains("#define"))
                    {
                        nextState = (DEFINE_STATE)states[level].row.Field<int>((int)TABLE_COLUMN.DEFINE);
                   }
                    
                    if (match.Success)
                    {
                        if (returnFromIF)
                        {
                            nextState = DEFINE_STATE.START;
                        }
                        else
                        {
                            nextState = (DEFINE_STATE)states[level].row.Field<int>((int)TABLE_COLUMN.INCLUDE);
                        }
                    }
                    if (input.Contains("#if"))
                    {
                        nextState = (DEFINE_STATE)states[level].row.Field<int>((int)TABLE_COLUMN.IF);
                        states.Add(new State_Variables());
                        level++;
                    }
                    if (input.Contains("#else"))
                    {
                        nextState = (DEFINE_STATE)states[level].row.Field<int>((int)TABLE_COLUMN.ELSE);
                    }
                    if (input.Contains("#endif"))
                    {
                        nextState = (DEFINE_STATE)states[level].row.Field<int>((int)TABLE_COLUMN.END_IF);
                    }
                    if ((nextState != DEFINE_STATE.ERROR) && (nextState != DEFINE_STATE.DO_NOT_CARE))
                    {
                        states[level].state = nextState;
                    }
                   
                    switch (nextState)
                    {
                        case DEFINE_STATE.NONE:  //stay at current state
                            Console.WriteLine("Did not find state at line {0}", line_number);
                            break;
                        case DEFINE_STATE.INVALID:
                            Console.WriteLine("Invalid IF/ELSE/END_IF at line {0}", line_number);
                            break;
                        case DEFINE_STATE.ERROR :
                            action = states[level].row.Field<ACTION>((int)TABLE_COLUMN.ACTION);
                            switch (action)
                            {
                                case ACTION.SET_DEFINE_LINE_NUMBER :
                                    Console.WriteLine("Define followed by Define at line {0}", states[level].define_Line_Number.ToString());
                                    states[level].define_Line_Number = line_number;
                                    break;
                                case ACTION.SET_DEFINE_IF_LINE_NUMBER :
                                    Console.WriteLine("Define in IF followed by Define by at line {0}", states[level].define_If_Line_Number.ToString());
                                    states[level].define_If_Line_Number = line_number;
                                    break;
                                case ACTION.SET_DEFINE_ELSE_LINE_NUMBER :
                                    Console.WriteLine("Define in ELSE followed by Define at line {0}", states[level].define_Else_Line_Number.ToString());
                                    states[level].define_Else_Line_Number = line_number;
                                    break;
                            }
                            break;
                        case DEFINE_STATE.SPECIAL:
                            Console.WriteLine("Define followed IF at line {0}", states[level].define_Line_Number.ToString());
                            nextState = DEFINE_STATE.FOUND_IF;
                            break;
                        default:
                            states[level].row = dt.AsEnumerable().Where(x => x.Field<DEFINE_STATE>((int)TABLE_COLUMN.STATE) == nextState).FirstOrDefault();
                                action = states[level].row.Field<ACTION>((int)TABLE_COLUMN.ACTION);
                                switch (action)
                                {
                                    case ACTION.RESET_DEFINE_LINE_NUMBER:
                                        states[level].define_Line_Number = 0;
                                        break;
                                    case ACTION.RESET_DEFINE_IF_LINE_NUMBER:
                                        states[level].define_If_Line_Number = 0;
                                        break;
                                    case ACTION.RESET_DEFINE_ELSE_LINE_NUMBER:
                                        states[level].define_Else_Line_Number = 0;
                                        break;
                                    case ACTION.SET_DEFINE_LINE_NUMBER:
                                        states[level].define_Line_Number = line_number;
                                        break;
                                    case ACTION.SET_DEFINE_IF_LINE_NUMBER:
                                        states[level].define_If_Line_Number = line_number;
                                        break;
                                    case ACTION.SET_DEFINE_ELSE_LINE_NUMBER:
                                        states[level].define_Else_Line_Number = line_number;
                                        break;
                                }
                                states[level].state = nextState;
                            
                            break;
                    }
                }
                //final checks
                int define_Line_Number = states[level].define_Line_Number;
                if (define_Line_Number != 0)
                {
                    Console.WriteLine("Define at line {0} does not have and include", define_Line_Number.ToString());
                }
                if (level != 0)
                {
                    Console.WriteLine("Did not close all IFs with End_If");
                }
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
     
    }
