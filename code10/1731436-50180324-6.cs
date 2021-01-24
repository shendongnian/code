    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace DrubBank
    {
        class Program
        {
            const string FILENANE = @"c:\temp\mini database.xml";
            static void Main(string[] args)
            {
                string connStr = DrugBank.Properties.Settings.Default.DrugBankConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                XmlReader reader = XmlReader.Create(FILENANE);
                while (!reader.EOF)
                {
                    if (reader.Name != "drug")
                    {
                        reader.ReadToFollowing("drug");
                    }
                    if (!reader.EOF)
                    {
                        XElement drug = (XElement)XElement.ReadFrom(reader);
                        AddDrug(conn, drug);
                    }
                }
            }
            public static void AddDrug(SqlConnection conn, XElement drug)
            {
                const string INSERT_DRUG =
                "INSERT INTO [DrugBank].[dbo].[Drugs] (" +
                "[Type],[Created],[Updated],[ID],[Name],[Description],[Case Number],[Unii],[State])" +
                " VALUES " +
                "(@Type, @Created, @Updated, @ID, @Name, @Description, @Case_Number, @Unii, @State)";
                
                SqlCommand drugCmd = new SqlCommand(INSERT_DRUG, conn);
                drugCmd.Parameters.Add("@Type", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Created", SqlDbType.DateTime);
                drugCmd.Parameters.Add("@Updated", SqlDbType.DateTime);
                drugCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                drugCmd.Parameters.Add("@Description", SqlDbType.VarChar, 256);
                drugCmd.Parameters.Add("@Case_Number", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Unii", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@State", SqlDbType.VarChar, 20);
                string dType = ((string)drug.Attribute("type")).Trim();
                DateTime created = (DateTime)drug.Attribute("created");
                DateTime updated = (DateTime)drug.Attribute("updated");
                List<XElement> drugbank_ids = drug.Elements().Where(x => x.Name.LocalName == "drugbank-id").ToList();
                const string INSERT_DRUG_ID =
                "INSERT INTO [DrugBank].[dbo].[IDs] (" +
                "[ID],[ALT ID])" +
                " VALUES " +
                "(@ID, @ALT_ID)";
                SqlCommand idCmd = new SqlCommand(INSERT_DRUG_ID, conn);
               idCmd.Parameters.Add("@ID", SqlDbType.VarChar, 256);
               idCmd.Parameters.Add("@ALT_ID", SqlDbType.VarChar, 20);
     
                string primaryID = (string)drugbank_ids.Where(x => x.Attribute("primary") != null).FirstOrDefault();
                foreach(string drugbank_id in drugbank_ids)
                {
                    idCmd.Parameters["@ID"].Value = primaryID;
                    idCmd.Parameters["@ALT_ID"].Value = drugbank_id;
                    idCmd.ExecuteNonQuery();
                }
                string name = ((string)drug.Elements().Where(x => x.Name.LocalName == "name").FirstOrDefault()).Trim();
                string description = ((string)drug.Elements().Where(x => x.Name.LocalName == "description").FirstOrDefault()).Trim();
                string case_number = ((string)drug.Elements().Where(x => x.Name.LocalName == "cas-number").FirstOrDefault()).Trim();
                string unii = ((string)drug.Elements().Where(x => x.Name.LocalName == "unii").FirstOrDefault()).Trim();
                string state = ((string)drug.Elements().Where(x => x.Name.LocalName == "state").FirstOrDefault()).Trim();
                drugCmd.Parameters["@Type"].Value = dType;
                drugCmd.Parameters["@Created"].Value = created;
                drugCmd.Parameters["@Updated"].Value = updated;
                drugCmd.Parameters["@ID"].Value = primaryID;
                drugCmd.Parameters["@Name"].Value = name;
                drugCmd.Parameters["@Description"].Value = description;
                drugCmd.Parameters["@Case_Number"].Value = case_number;
                drugCmd.Parameters["@Unii"].Value = unii;
                drugCmd.Parameters["@State"].Value = state;
                drugCmd.ExecuteNonQuery();
                AddArticles(conn, drug, primaryID);
                AddInteractions(conn, drug, primaryID);
            }
            public static void AddArticles(SqlConnection conn, XElement drug, string id)
            {
                const string INSERT_DRUG_ARTICLE =
                    "INSERT INTO [DrugBank].[dbo].[Articles] (" +
                    "[ID],[Pubmed ID],[Citation])" +
                    " VALUES " +
                    "(@ID,@Pubmed_ID, @Citation)";
                SqlCommand articleCmd = new SqlCommand(INSERT_DRUG_ARTICLE, conn);
                articleCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                articleCmd.Parameters.Add("@Pubmed_ID", SqlDbType.VarChar, 256);
                articleCmd.Parameters.Add("@Citation", SqlDbType.VarChar, 20);
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName ==("article")))
                {
                    string pubmed_id = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "pubmed-id").FirstOrDefault()).Trim();
                    string citation = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "citation").FirstOrDefault()).Trim();
                    articleCmd.Parameters["@ID"].Value = id;
                    articleCmd.Parameters["@Pubmed_ID"].Value = pubmed_id;
                    articleCmd.Parameters["@Citation"].Value = citation;
                    articleCmd.ExecuteNonQuery();
                }
                const string INSERT_DRUG_LINK =
                    "INSERT INTO [DrugBank].[dbo].[Links] (" +
                    "[ID],[Title],[URL])" +
                    " VALUES " +
                    "(@ID,@Title, @URL)";
                SqlCommand linkCmd = new SqlCommand(INSERT_DRUG_LINK, conn);
                linkCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                linkCmd.Parameters.Add("@Title", SqlDbType.VarChar, 256);
                linkCmd.Parameters.Add("@URL", SqlDbType.VarChar, 64);
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("link")))
                {
                    string title = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "title").FirstOrDefault()).Trim();
                    string url = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "url").FirstOrDefault()).Trim();
                    linkCmd.Parameters["@ID"].Value = id;
                    linkCmd.Parameters["@Title"].Value = title;
                    linkCmd.Parameters["@URL"].Value = url;
                    linkCmd.ExecuteNonQuery();
                }
            }
            public static void AddInteractions(SqlConnection conn, XElement drug, string id)
            {
                const string INSERT_DRUG_INTERACTION =
                    "INSERT INTO [DrugBank].[dbo].[Interactions] (" +
                    "[ID],[Interaction ID],[Description])" +
                    " VALUES " +
                    "(@ID,@Interaction_ID, @Description)";
                SqlCommand interactionCmd = new SqlCommand(INSERT_DRUG_INTERACTION, conn);
                interactionCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                interactionCmd.Parameters.Add("@Interaction_ID", SqlDbType.VarChar, 20);
                interactionCmd.Parameters.Add("@Description", SqlDbType.VarChar, 256);
                foreach (XElement interaction in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("drug-interaction")))
                {
                    string interactionID = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "drugbank-id").FirstOrDefault()).Trim();
                    string description = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "description").FirstOrDefault()).Trim();
                    interactionCmd.Parameters["@ID"].Value = id;
                    interactionCmd.Parameters["@Interaction_ID"].Value = interactionID;
                    interactionCmd.Parameters["@Description"].Value = description;
                    interactionCmd.ExecuteNonQuery();
                }
            }
        }
    }
