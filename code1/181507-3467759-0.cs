    static void Main(string[] args)
    {
        CodeGenerator gen = new CodeGenerator();
        gen.ReadFile("Input.txt");
    }
    public class CodeGenerator
    {
        public void ReadFile(string filename)
        {
            StreamReader fs = new StreamReader(filename);
            string line;
            CSharpCode CG = new CSharpCode();
        
            while ((line = fs.ReadLine()) != null)
            {
                line = line.TrimEnd('\n');
        
                if (Regex.IsMatch(line, @"^\s*S"))
                    CG.BlankLine();
                else if (Regex.IsMatch(line, @"^\#(.*)")) // match comments
                    CG.Comment(line.TrimStart('#'));
                else if (Regex.IsMatch(line, @"^M\s*(.+)")) // start msg
                    CG.StartMsg(line.Split(' ')[1]);
                else if (Regex.IsMatch(line, @"^E")) // end msg
                    CG.EndMsg();
                else if (Regex.IsMatch(line, @"^F\s*(\w+)")) // simple type
                    CG.SimpleType(Regex.Split(line, @"^F\s*(\w+)")[1], Regex.Split(line, @"^F\s*(\w+)")[2]);
                else
                    Console.WriteLine("Invalid line " + line);
            }
        }
    }
        
    // Code Generator for C#
    public class CSharpCode
    {
        public void BlankLine() { Console.WriteLine(); }
        public void Comment(string comment) { Console.WriteLine("//" + comment); }
        public void StartMsg(string name) { Console.WriteLine("public struct " + name + "{"); }
        public void EndMsg() { Console.WriteLine("}"); }
        public void SimpleType(string name, string type)
        {
            if(type.Contains("char["))
                type = "string";
    
            Console.WriteLine(string.Format("\t{0} {1};", type.Trim(), name));
        }
    }  
