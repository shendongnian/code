    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                new Order(FILENAME);
            }
        }
        public class Order
        {
            [ScaffoldColumn(false)]
            public int Id { get; set; }
            public string SLOCATION { get; set; }
            public string MQUOTE { get; set; }
            public string MCPAYDATE { get; set; }
            public string MTAXNO { get; set; }
            public string MCOUNTY { get; set; }
            public string MCUSTCAT { get; set; }
            public int MRREF { get; set; }
            public int MLREF { get; set; }
            public int MLREC { get; set; }
            public decimal MSUBTOT { get; set; }
            public string MCALL { get; set; }
            public string PCATA { get; set; }
            public string PCATB { get; set; }
            public string PCATC { get; set; }
            public string PCATD { get; set; }
            public bool PCATE { get; set; }
            public bool PCATF { get; set; }
            public bool PCATG { get; set; }
            public bool PCATH { get; set; }
            public bool PCATI { get; set; }
            public bool PCATJ { get; set; }
            public bool PCATK { get; set; }
            public bool PCATL { get; set; }
            public bool PCATM { get; set; }
            public bool PCATN { get; set; }
            public bool PCATO { get; set; }
            public int PQUANA { get; set; }
            public int PQUANB { get; set; }
            public int PQUANC { get; set; }
            public int PQUAND { get; set; }
            public bool PQUANE { get; set; }
            public bool PQUANF { get; set; }
            public bool PQUANG { get; set; }
            public bool PQUANH { get; set; }
            public bool PQUANI { get; set; }
            public bool PQUANJ { get; set; }
            public bool PQUANK { get; set; }
            public bool PQUANL { get; set; }
            public bool PQUANM { get; set; }
            public bool PQUANN { get; set; }
            public bool PQUANO { get; set; }
            public string PDONEA { get; set; }
            public string PDONEB { get; set; }
            public string PDONEC { get; set; }
            public string PDONED { get; set; }
            public bool PDONEE { get; set; }
            public bool PDONEF { get; set; }
            public bool PDONEG { get; set; }
            public bool PDONEH { get; set; }
            public bool PDONEI { get; set; }
            public bool PDONEJ { get; set; }
            public bool PDONEK { get; set; }
            public bool PDONEL { get; set; }
            public bool PDONEM { get; set; }
            public bool PDONEN { get; set; }
            public bool PDONEO { get; set; }
            public string PDTWOA { get; set; }
            public string PDTWOB { get; set; }
            public string PDTWOC { get; set; }
            public string PDTWOD { get; set; }
            public bool PDTWOE { get; set; }
            public bool PDTWOF { get; set; }
            public bool PDTWOG { get; set; }
            public bool PDTWOH { get; set; }
            public bool PDTWOI { get; set; }
            public bool PDTWOJ { get; set; }
            public bool PDTWOK { get; set; }
            public bool PDTWOL { get; set; }
            public bool PDTWOM { get; set; }
            public bool PDTWON { get; set; }
            public bool PDTWOO { get; set; }
            public decimal PUNITA { get; set; }
            public int PUNITB { get; set; }
            public int PUNITC { get; set; }
            public int PUNITD { get; set; }
            public int PUNITE { get; set; }
            public int PUNITF { get; set; }
            public int PUNITG { get; set; }
            public int PUNITH { get; set; }
            public int PUNITI { get; set; }
            public int PUNITJ { get; set; }
            public int PUNITK { get; set; }
            public int PUNITL { get; set; }
            public int PUNITM { get; set; }
            public int PUNITN { get; set; }
            public int PUNITO { get; set; }
            public decimal PTOTALA { get; set; }
            public int PTOTALB { get; set; }
            public int PTOTALC { get; set; }
            public int PTOTALD { get; set; }
            public int PTOTALE { get; set; }
            public int PTOTALF { get; set; }
            public int PTOTALG { get; set; }
            public int PTOTALH { get; set; }
            public int PTOTALI { get; set; }
            public int PTOTALJ { get; set; }
            public int PTOTALK { get; set; }
            public int PTOTALL { get; set; }
            public int PTOTALM { get; set; }
            public int PTOTALN { get; set; }
            public int PTOTALO { get; set; }
            public string XPTCK { get; set; }
            public string MTUSER { get; set; }
            public int SELECTNUM { get; set; }
            public string SELECT { get; set; }
            public string CONTINUE { get; set; }
            public string MDATE { get; set; }
            public string MPUDATE { get; set; }
            public string MPAYDATE { get; set; }
            public string MGONEDATE { get; set; }
            public string MSHPNAME { get; set; }
            public string MSHPCNME { get; set; }
            public string MSHPAD1 { get; set; }
            public string MSHPAD2 { get; set; }
            public string MSHPCITY { get; set; }
            public string MEMAIL { get; set; }
            public string MPHOTO { get; set; }
            public string MSHPST { get; set; }
            public string MSTATE { get; set; }
            public string MGONEPER { get; set; }
            public string MSHPZIP { get; set; }
            public string MZIP { get; set; }
            public string MSHIPVIA { get; set; }
            public string MPUTIME { get; set; }
            public string MGONETIME { get; set; }
            public string MCASH { get; set; }
            public string MLETTER { get; set; }
            public string MYTAX { get; set; }
            public string MLABEL { get; set; }
            public string MNUMBER { get; set; }
            public string MINVNO { get; set; }
            public string MCUSTPO { get; set; }
            public string MSHIPFROM { get; set; }
            public string MCONTACT { get; set; }
            public string MPHONE { get; set; }
            public string MFAX { get; set; }
            public string MCELL { get; set; }
            public string MCOMMENT { get; set; }
            public string MCOMMENT1 { get; set; }
            public string MACCTN { get; set; }
            public string MSTREET { get; set; }
            public string MCITY { get; set; }
            public string MCHECKNO { get; set; }
            public int MENGRAV { get; set; }
            public decimal MTAX { get; set; }
            public decimal MSHIPPING { get; set; }
            public decimal MTOTAL { get; set; }
            public decimal MPAYMENT { get; set; }
            public string MCC { get; set; }
            public string XSALESPER { get; set; }
            public string MSNAME { get; set; }
            public string MEVENTDTE { get; set; }
            public string MOPENACCT { get; set; }
            public string MPAYPERSON { get; set; }
            public string ANS { get; set; }
            public string MFILENAME { get; set; }
            public Order() { }
            public Order(string filename)
            {
                string patternNumber = @"\d+(.\d+)?";
                //use string read instead of StreamReader if data is going from a web response
                StreamReader reader = new StreamReader(filename);
                string inputLine = "";
                string type = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if(!inputLine.StartsWith("\""))
                        {
                            string name = inputLine.Substring(0, 12).Trim();
                            type = inputLine.Substring(12, 9).Trim();
                            string value = inputLine.Substring(21).Trim();
                            switch (type)
                            {
                                case "Pub   C" :
                                    Write(name, value.Replace("\"", "").Trim());
                                    break;
                                case "Pub   N":
                                    string strNumber = Regex.Match(value, patternNumber).Value;
                                    object num = strNumber.Contains(".") ? decimal.Parse(strNumber) : int.Parse(strNumber);
                                    Write(name, num);
                                    break;
                                case "Pub   L":
                                    bool true_false = value == ".F." ? false : true;
                                    Write(name, true_false);
                                    break;
                            }
                        }
                    }
                }
            }
            public void Write(string name, object value)
            {
                switch(name)
                {
                    case "Id" :
                        Id = Convert.ToInt32(value);
                        break;
                    case "SLOCATION" :
                        SLOCATION = (string)value;
                        break;
                    case "MQUOTE":
                        MQUOTE = (string)value;
                        break;
                    case "MCPAYDATE":
                        MCPAYDATE = (string)value;
                        break;
                    case "MTAXNO":
                        MTAXNO = (string)value;
                        break;
                    case "MCOUNTY":
                        MCOUNTY = (string)value;
                        break;
                    case "MCUSTCAT":
                        MCUSTCAT = (string)value;
                        break;
                    case "MRREF":
                        MRREF = Convert.ToInt32(value);
                        break;
                    case "MLREF":
                        MLREF = Convert.ToInt32(value);
                        break;
                    case "MLREC":
                        MLREC = Convert.ToInt32(value);
                        break;
                    case "MSUBTOT":
                        MSUBTOT = (decimal)value;
                        break;
                    case "MCALL":
                        MCALL = (string)value;
                        break;
                    case "PCATA":
                        PCATA = (string)value;
                        break;
                    case "PCATB":
                        PCATB = (string)value;
                        break;
                    case "PCATC":
                        PCATC = (string)value;
                        break;
                    case "PCATD":
                        PCATD = (string)value;
                        break;
                    case "PCATE":
                        PCATE = (bool)value;
                        break;
                    case "PCATF":
                        PCATF = (bool)value;
                        break;
                    case "PCATG":
                        PCATG = (bool)value;
                        break;
                    case "PCATH":
                        PCATH = (bool)value;
                        break;
                    case "PCATI":
                        PCATI = (bool)value;
                        break;
                    case "PCATJ":
                        PCATJ = (bool)value;
                        break;
                    case "PCATK":
                        PCATK = (bool)value;
                        break;
                    case "PCATL":
                        PCATL = (bool)value;
                        break;
                    case "PCATM":
                        PCATM = (bool)value;
                        break;
                    case "PCATN":
                        PCATN = (bool)value;
                        break;
                    case "PCATO":
                        PCATO = (bool)value;
                        break;
                    case "PQUANA":
                        PQUANA = Convert.ToInt32(value);
                        break;
                    case "PQUANB":
                        PQUANB = Convert.ToInt32(value);
                        break;
                    case "PQUANC":
                        PQUANC = Convert.ToInt32(value);
                        break;
                    case "PQUAND":
                        PQUAND = Convert.ToInt32(value);
                        break;
                    case "PQUANE":
                        PQUANE = (bool)value;
                        break;
                    case "PQUANF":
                        PQUANF = (bool)value;
                        break;
                    case "PQUANG":
                        PQUANG = (bool)value;
                        break;
                    case "PQUANH":
                        PQUANH = (bool)value;
                        break;
                    case "PQUANI":
                        PQUANI = (bool)value;
                        break;
                    case "PQUANJ":
                        PQUANJ = (bool)value;
                        break;
                    case "PQUANK":
                        PQUANK = (bool)value;
                        break;
                    case "PQUANL":
                        PQUANL = (bool)value;
                        break;
                    case "PQUANM":
                        PQUANM = (bool)value;
                        break;
                    case "PQUANN":
                        PQUANN = (bool)value;
                        break;
                    case "PQUANO":
                        PQUANO = (bool)value;
                        break;
                    case "PDONEA":
                        PDONEA = (string)value;
                        break;
                    case "PDONEB":
                        PDONEB = (string)value;
                        break;
                    case "PDONEC":
                        PDONEC = (string)value;
                        break;
                    case "PDONED":
                        PDONED = (string)value;
                        break;
                    case "PDONEE":
                        PDONEE = (bool)value;
                        break;
                    case "PDONEF":
                        PDONEF = (bool)value;
                        break;
                    case "PDONEG":
                        PDONEG = (bool)value;
                        break;
                    case "PDONEH":
                        PDONEH = (bool)value;
                        break;
                    case "PDONEI":
                        PDONEI = (bool)value;
                        break;
                    case "PDONEJ":
                        PDONEJ = (bool)value;
                        break;
                    case "PDONEK":
                        PDONEK = (bool)value;
                        break;
                    case "PDONEL":
                        PDONEL = (bool)value;
                        break;
                    case "PDONEM":
                        PDONEM = (bool)value;
                        break;
                    case "PDONEN":
                        PDONEN = (bool)value;
                        break;
                    case "PDONEO":
                        PDONEO = (bool)value;
                        break;
                    case "PDTWOA":
                        PDTWOA = (string)value;
                        break;
                    case "PDTWOB":
                        PDTWOB = (string)value;
                        break;
                    case "PDTWOC":
                        PDTWOC = (string)value;
                        break;
                    case "PDTWOD":
                        PDTWOD = (string)value;
                        break;
                    case "PDTWOE":
                        PDTWOE = (bool)value;
                        break;
                    case "PDTWOF":
                        PDTWOF = (bool)value;
                        break;
                    case "PDTWOG":
                        PDTWOG = (bool)value;
                        break;
                    case "PDTWOH":
                        PDTWOH = (bool)value;
                        break;
                    case "PDTWOI":
                        PDTWOI = (bool)value;
                        break;
                    case "PDTWOJ":
                        PDTWOJ = (bool)value;
                        break;
                    case "PDTWOK":
                        PDTWOK = (bool)value;
                        break;
                    case "PDTWOL":
                        PDTWOL = (bool)value;
                        break;
                    case "PDTWOM":
                        PDTWOM = (bool)value;
                        break;
                    case "PDTWON":
                        PDTWON = (bool)value;
                        break;
                    case "PDTWOO":
                        PDTWOO = (bool)value;
                        break;
                    case "PUNITA":
                        PUNITA = (decimal)value;
                        break;
                    case "PUNITB":
                        PUNITB = Convert.ToInt32(value);
                        break;
                    case "PUNITC":
                        PUNITC = Convert.ToInt32(value);
                        break;
                    case "PUNITD":
                        PUNITD = Convert.ToInt32(value);
                        break;
                    case "PUNITE":
                        PUNITE = Convert.ToInt32(value);
                        break;
                    case "PUNITF":
                        PUNITF = Convert.ToInt32(value);
                        break;
                    case "PUNITG":
                        PUNITG = Convert.ToInt32(value);
                        break;
                    case "PUNITH":
                        PUNITH = Convert.ToInt32(value);
                        break;
                    case "PUNITI":
                        PUNITI = Convert.ToInt32(value);
                        break;
                    case "PUNITJ":
                        PUNITJ = Convert.ToInt32(value);
                        break;
                    case "PUNITK":
                        PUNITK  = Convert.ToInt32(value);
                        break;
                    case "PUNITL":
                        PUNITL = Convert.ToInt32(value);
                        break;
                    case "PUNITM":
                        PUNITM = Convert.ToInt32(value);
                        break;
                    case "PUNITN":
                        PUNITN = Convert.ToInt32(value);
                        break;
                    case "PUNITO":
                        PUNITO = Convert.ToInt32(value);
                        break;
                    case "PTOTALA":
                        PTOTALA = Convert.ToInt32(value);
                        break;
                    case "PTOTALB":
                        PTOTALB = Convert.ToInt32(value);
                        break;
                    case "PTOTALC":
                        PTOTALC = Convert.ToInt32(value);
                        break;
                    case "PTOTALD":
                        PTOTALD = Convert.ToInt32(value);
                        break;
                    case "PTOTALE":
                        PTOTALE = Convert.ToInt32(value);
                        break;
                    case "PTOTALF":
                        PTOTALF = Convert.ToInt32(value);
                        break;
                    case "PTOTALG":
                        PTOTALG = Convert.ToInt32(value);
                        break;
                    case "PTOTALH":
                        PTOTALH = Convert.ToInt32(value);
                        break;
                    case "PTOTALI":
                        PTOTALI = Convert.ToInt32(value);
                        break;
                    case "PTOTALJ":
                        PTOTALJ = Convert.ToInt32(value);
                        break;
                    case "PTOTALK":
                        PTOTALK = Convert.ToInt32(value);
                        break;
                    case "PTOTALL":
                        PTOTALL = Convert.ToInt32(value);
                        break;
                    case "PTOTALM":
                        PTOTALM = Convert.ToInt32(value);
                        break;
                    case "PTOTALN":
                        PTOTALN = Convert.ToInt32(value);
                        break;
                    case "PTOTALO":
                        PTOTALO = Convert.ToInt32(value);
                        break;
                    case "XPTCK":
                        XPTCK = (string)value;
                        break;
                    case "MTUSER":
                        MTUSER = (string)value;
                        break;
                    case "SELECTNUM":
                        SELECTNUM = Convert.ToInt32(value);
                        break;
                    case "SELECT":
                        SELECT = (string)value;
                        break;
                    case "CONTINUE":
                        CONTINUE = (string)value;
                        break;
                    case "MDATE":
                        MDATE = (string)value;
                        break;
                    case "MPUDATE":
                        MPUDATE = (string)value;
                        break;
                    case "MPAYDATE":
                        MPAYDATE = (string)value;
                        break;
                    case "MGONEDATE":
                        MGONEDATE = (string)value;
                        break;
                    case "MSHPNAME":
                        MSHPNAME = (string)value;
                        break;
                    case "MSHPCNME":
                        MSHPCNME = (string)value;
                        break;
                    case "MSHPAD1":
                        MSHPAD1 = (string)value;
                        break;
                    case "MSHPAD2":
                        MSHPAD2 = (string)value;
                        break;
                    case "MSHPCITY":
                        MSHPCITY = (string)value;
                        break;
                    case "MEMAIL":
                        MEMAIL = (string)value;
                        break;
                    case "MPHOTO":
                        MPHOTO = (string)value;
                        break;
                    case "MSHPST":
                        MSHPST = (string)value;
                        break;
                    case "MSTATE":
                        MSTATE = (string)value;
                        break;
                    case "MGONEPER":
                        MGONEPER = (string)value;
                        break;
                    case "MSHPZIP":
                        MSHPZIP = (string)value;
                        break;
                    case "MZIP":
                        MZIP = (string)value;
                        break;
                    case "MSHIPVIA":
                        MSHIPVIA = (string)value;
                        break;
                    case "MPUTIME":
                        MPUTIME = (string)value;
                        break;
                    case "MGONETIME":
                        MGONETIME = (string)value;
                        break;
                    case "MCASH":
                        MCASH = (string)value;
                        break;
                    case "MLETTER":
                        MLETTER = (string)value;
                        break;
                    case "MYTAX":
                        MYTAX = (string)value;
                        break;
                    case "MLABEL":
                        MLABEL = (string)value;
                        break;
                    case "MNUMBER":
                        MNUMBER = (string)value;
                        break;
                    case "MINVNO":
                        MINVNO = (string)value;
                        break;
                    case "MCUSTPO":
                        MCUSTPO = (string)value;
                        break;
                    case "MSHIPFROM":
                        MSHIPFROM = (string)value;
                        break;
                    case "MCONTACT":
                        MCONTACT = (string)value;
                        break;
                    case "MPHONE":
                        MPHONE = (string)value;
                        break;
                    case "MFAX":
                        MFAX = (string)value;
                        break;
                    case "MCELL":
                        MCELL = (string)value;
                        break;
                    case "MCOMMENT":
                        MCOMMENT = (string)value;
                        break;
                    case "MCOMMENT1":
                        MCOMMENT1 = (string)value;
                        break;
                    case "MACCTN":
                        MACCTN = (string)value;
                        break;
                    case "MSTREET":
                        MSTREET = (string)value;
                        break;
                    case "MCITY":
                        MCITY = (string)value;
                        break;
                    case "MCHECKNO":
                        MCHECKNO = (string)value;
                        break;
                    case "MENGRAV":
                        MENGRAV = Convert.ToInt32(value);
                        break;
                    case "MTAX":
                        MTAX = Convert.ToInt32(value);
                        break;
                    case "MSHIPPING":
                        MSHIPPING = Convert.ToInt32(value);
                        break;
                    case "MTOTAL":
                        MTOTAL = Convert.ToInt32(value);
                        break;
                    case "MPAYMENT":
                        break;
                    case "MCC":
                        MCC = (string)value;
                        break;
                    case "XSALESPER":
                        XSALESPER = (string)value;
                        break;
                    case "MSNAME":
                        MSNAME = (string)value;
                        break;
                    case "MEVENTDTE":
                        MEVENTDTE = (string)value;
                        break;
                    case "MOPENACCT":
                        MOPENACCT = (string)value;
                        break;
                    case "MPAYPERSON":
                        MPAYPERSON = (string)value;
                        break;
                    case "ANS":
                        ANS = (string)value;
                        break;
                    case "MFILENAME":
                        MFILENAME = (string)value;
                        break;
                }
            }
        }
    }
      
