    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Globalization;
    namespace ConsoleApplication37
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = Test.GetCategorias(FILENAME);
            }
        }
        public class Test
        {
            public static DataTable GetCategorias(string filename)
            {
                DataTable oDataTable = null;
                string[] columnNameList = new string[6] { "NomeDeRegime", "NomeDeDescricao", "NomeDeRegiao", "NomeDeGrupos", "NomeDeServiços", "LinkDeServiços" };
                oDataTable = new DataTable();
                oDataTable.Locale = CultureInfo.InvariantCulture;
                foreach (string columnName in columnNameList)
                {
                    oDataTable.Columns.Add(columnName, typeof(string));
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filename);
                XmlNodeList ListaDeRegimes = null;
                ListaDeRegimes = xmlDoc.SelectNodes("//ListaDeRegimes");
                //if (ListaDeRegimes != null)
                foreach (XmlNode Regime in ListaDeRegimes)
                {
                    string NomeDeRegime = "";
                    string NomeDeDescricao = "";
                    string NomeDeRegiao = "";
                    string NomeDeGrupos = "";
                    string NomeDeServiços = "";
                    string LinkDeServiços = "";
                    XmlNodeList RegimeList = Regime.SelectNodes("//Regime");
                    foreach (XmlNode RegimeNode in RegimeList)
                    {
                        NomeDeRegime = RegimeNode.SelectSingleNode("nome").FirstChild.Value;
                        if (RegimeNode.SelectSingleNode("descricao") != null)
                        {
                            NomeDeDescricao = RegimeNode.SelectSingleNode("descricao").FirstChild.Value;
                        }
                        //Listar lista do nome de regiao
                        string[] valueList = valueList = new string[6] { NomeDeRegime, NomeDeDescricao, "", "", "", "" };
                        oDataTable.Rows.Add(valueList);
                        foreach (XmlNode childnodes in RegimeNode.ChildNodes)
                        {
                            if (childnodes.Name == "região")
                            {
                                if (childnodes.Attributes["nome"].Value != null)
                                {
                                    NomeDeRegiao = childnodes.Attributes["nome"].Value;
                                }
                                else
                                {
                                    NomeDeRegiao = "";
                                }
                                valueList = new string[6] { "", "", NomeDeRegiao, "", "", "" };
                                oDataTable.Rows.Add(valueList);
                                foreach (XmlNode NodeGrupos in childnodes)
                                {
                                    if (NodeGrupos.Attributes["nome"] == null)
                                    {
                                        NomeDeGrupos = "";
                                    }
                                    else if (NodeGrupos.Attributes["nome"].Value != null)
                                    {
                                        NomeDeGrupos = NodeGrupos.Attributes["nome"].Value;
                                    }
                                    else
                                    {
                                        NomeDeGrupos = "";
                                    }
                                    valueList = new string[6] { "", "", "", NomeDeGrupos, "", "" };
                                    oDataTable.Rows.Add(valueList);
                                    foreach (XmlNode NodeServiços in NodeGrupos)
                                    {
                                        if (NodeServiços.SelectSingleNode("nome") != null)
                                        {
                                            NomeDeServiços = NodeServiços.SelectSingleNode("nome").FirstChild.Value;
                                            if (NodeServiços.SelectSingleNode("link") != null)
                                            {
                                                LinkDeServiços = NodeServiços.SelectSingleNode("link").FirstChild.Value;
                                            }
                                            else
                                            {
                                                LinkDeServiços = "";
                                            }
                                        }
                                        else
                                        {
                                            NomeDeServiços = "";
                                        }
                                        valueList = new string[6] { "", "", "", "", NomeDeServiços, LinkDeServiços };
                                        oDataTable.Rows.Add(valueList);
                                    }
                                }
                            }
                        }
                    }
                }
                return oDataTable;
            }
        }
    }
