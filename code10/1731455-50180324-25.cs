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
            const string FILENAME = @"c:\temp\full database.xml";
            static void Main(string[] args)
            {
                new UploadXml(FILENAME);
            }
        }
        public class UploadXml
        {
            const string INSERT_DRUG_PRODUCT =
                "INSERT INTO [DrugBank].[dbo].[Products] (" +
                "[ID],[Name],[Labeller], [NDC ID], [NDC Product Code], [DPD ID]," +
                "[EMA Product Code],[EMA MA Number],[Started Marketing On], [Ended Marketing On], [Dosage Form]," +
                "[Strength],[Route],[FDA Application Number],[Generic],[Over The Counter],[Approved],[Country],[Source])" +
                " VALUES " +
                "(@ID,@Name,@Labeller, @NDC_ID, @NDC_Product_Code,@DPD_ID," +
                "@EMA_Product_Code,@EMA_MA_Number,@Started_Marketing_On, @Ended_Marketing_On, @Dosage_Form," +
                "@Strength,@Route,@FDA_Application_Number,@Generic,@Over_The_Counter,@Approved,@Country,@Source)";
            const string INSERT_DRUG_ID =
                "INSERT INTO [DrugBank].[dbo].[IDs] (" +
                "[ID],[ALT ID])" +
                " VALUES " +
                "(@ID, @ALT_ID)";
            
            const string INSERT_DRUG_INTERACTION =
                "INSERT INTO [DrugBank].[dbo].[Interactions] (" +
                "[ID],[Interaction ID],[Description])" +
                " VALUES " +
                "(@ID,@Interaction_ID, @Description)";
            const string INSERT_DRUG_ARTICLE =
                "INSERT INTO [DrugBank].[dbo].[Articles] (" +
                "[ID],[Pubmed ID],[Citation])" +
                " VALUES " +
                "(@ID,@Pubmed_ID, @Citation)";
            const string INSERT_DRUG_LINK =
                 "INSERT INTO [DrugBank].[dbo].[Links] (" +
                 "[ID],[Title],[URL])" +
                 " VALUES " +
                 "(@ID,@Title, @URL)";
            const string INSERT_DRUG =
                "INSERT INTO [DrugBank].[dbo].[Drugs] (" +
                "[Type],[Created],[Updated],[ID],[Name],[Description],[Case Number],[Unii],[State]," +
                "[Synthesis Reference],[Indication] ,[Pharmacodynamics] ,[Mechanism of Action], [Toxicity]," +
                "[Metabolism] , [Absorption] ,[Half Life], [Protein Binding]," +
                "[Route of Eelimination], [Volume of Distribution] ,[Clearance])" +
                " VALUES " +
                "(@Type, @Created, @Updated, @ID, @Name, @Description, @Case_Number, @Unii, @State," +
                 "@Synthesis_Reference,@Indication ,@Pharmacodynamics ,@Mechanism_of_Action, @Toxicity," +
                 "@Metabolism , @Absorption ,@Half_Life, @Protein_Binding," +
                 "@Route_of_Elimination, @Volume_of_Distribution ,@Clearance)";
            
            SqlCommand productCmd = null;
            SqlCommand interactionCmd = null;
            SqlCommand articleCmd = null;
            SqlCommand linkCmd = null;
            SqlCommand drugCmd = null;
            SqlCommand idCmd = null;
            public UploadXml(string filename)
            {
                string connStr = DrugBank.Properties.Settings.Default.DrugBankConnectionString;
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                drugCmd = new SqlCommand(INSERT_DRUG, conn);
                drugCmd.Parameters.Add("@Type", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Created", SqlDbType.DateTime);
                drugCmd.Parameters.Add("@Updated", SqlDbType.DateTime);
                drugCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                drugCmd.Parameters.Add("@Description", SqlDbType.VarChar);
                drugCmd.Parameters.Add("@Case_Number", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Unii", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@State", SqlDbType.VarChar, 20);
                drugCmd.Parameters.Add("@Synthesis_reference", SqlDbType.VarChar, 1024);
                drugCmd.Parameters.Add("@Indication", SqlDbType.VarChar);
                drugCmd.Parameters.Add("@Pharmacodynamics", SqlDbType.VarChar, 1024);
                drugCmd.Parameters.Add("@Mechanism_of_Action", SqlDbType.VarChar, 1024);
                drugCmd.Parameters.Add("@Toxicity", SqlDbType.VarChar, 1024);
                drugCmd.Parameters.Add("@Metabolism", SqlDbType.VarChar);
                drugCmd.Parameters.Add("@Absorption", SqlDbType.VarChar, 1024);
                drugCmd.Parameters.Add("@Half_Life", SqlDbType.VarChar, 256);
                drugCmd.Parameters.Add("@Protein_Binding", SqlDbType.VarChar, 64);
                drugCmd.Parameters.Add("@Route_of_Elimination", SqlDbType.VarChar);
                drugCmd.Parameters.Add("@Volume_of_Distribution", SqlDbType.VarChar);
                drugCmd.Parameters.Add("@Clearance", SqlDbType.VarChar);
                idCmd = new SqlCommand(INSERT_DRUG_ID, conn);
                idCmd.Parameters.Add("@ID", SqlDbType.VarChar, 256);
                idCmd.Parameters.Add("@ALT_ID", SqlDbType.VarChar, 20);
                articleCmd = new SqlCommand(INSERT_DRUG_ARTICLE, conn);
                
                articleCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                articleCmd.Parameters.Add("@Pubmed_ID", SqlDbType.VarChar, 256);
                articleCmd.Parameters.Add("@Citation", SqlDbType.VarChar, 20);
                linkCmd = new SqlCommand(INSERT_DRUG_LINK, conn);
                linkCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                linkCmd.Parameters.Add("@Title", SqlDbType.VarChar, 256);
                linkCmd.Parameters.Add("@URL", SqlDbType.VarChar, 64);
                interactionCmd = new SqlCommand(INSERT_DRUG_INTERACTION, conn);
                interactionCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                interactionCmd.Parameters.Add("@Interaction_ID", SqlDbType.VarChar, 20);
                interactionCmd.Parameters.Add("@Description", SqlDbType.VarChar, 256);
                productCmd = new SqlCommand(INSERT_DRUG_PRODUCT, conn);
                productCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Name", SqlDbType.VarChar, 128);
                productCmd.Parameters.Add("@Labeller", SqlDbType.VarChar, 64);
                productCmd.Parameters.Add("@NDC_ID", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@NDC_Product_Code", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@DPD_ID", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@EMA_Product_Code", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@EMA_MA_Number", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Started_Marketing_On", SqlDbType.DateTime2, 20);
                productCmd.Parameters.Add("@Ended_Marketing_On", SqlDbType.DateTime2, 20);
                productCmd.Parameters.Add("@Dosage_Form", SqlDbType.VarChar, 64);
                productCmd.Parameters.Add("@Strength", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Route", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@FDA_Application_Number", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Generic", SqlDbType.Bit);
                productCmd.Parameters.Add("@Over_The_Counter", SqlDbType.Bit);
                productCmd.Parameters.Add("@Approved", SqlDbType.Bit);
                productCmd.Parameters.Add("@Country", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Source", SqlDbType.VarChar, 20);
                XmlReader reader = XmlReader.Create(filename);
                while (!reader.EOF)
                {
                    if (reader.Name != "drug")
                    {
                        reader.ReadToFollowing("drug");
                    }
                    if (!reader.EOF)
                    {
                        XElement drug = (XElement)XElement.ReadFrom(reader);
                        string primaryID = (string)drug.Elements().Where(x => (x.Name.LocalName == "drugbank-id") && (x.Attribute("primary") != null)).FirstOrDefault();
                        AddDrug(conn, drug, primaryID);
                        AddArticles(conn, drug, primaryID);
                        AddInteractions(conn, drug, primaryID);
                        AddProducts(conn, drug, primaryID);
                    }
                }
            }
            public void AddDrug(SqlConnection conn, XElement drug, string primaryID)
            {
                string dType = ((string)drug.Attribute("type")).Trim();
                DateTime created = (DateTime)drug.Attribute("created");
                DateTime updated = (DateTime)drug.Attribute("updated");
                List<XElement> drugbank_ids = drug.Elements().Where(x => (x.Name.LocalName == "drugbank-id") && (x.Attribute("primary") != null)).ToList();
                string name = ((string)drug.Elements().Where(x => x.Name.LocalName == "name").FirstOrDefault()).Trim();
                foreach (string drugbank_id in drugbank_ids)
                {
                    idCmd.Parameters["@ID"].Value = primaryID;
                    idCmd.Parameters["@ALT_ID"].Value = drugbank_id;
                    idCmd.ExecuteNonQuery();
                }
                string description = ((string)drug.Elements().Where(x => x.Name.LocalName == "description").FirstOrDefault()).Trim();
                int za = description.Length;
                string case_number = ((string)drug.Elements().Where(x => x.Name.LocalName == "cas-number").FirstOrDefault());
                int zb = case_number.Length;
                string unii = ((string)drug.Elements().Where(x => x.Name.LocalName == "unii").FirstOrDefault());
                int zc = unii.Length;
                string state = (drug.Elements().Where(x => x.Name.LocalName == "state").FirstOrDefault() == null) ? "" : ((string)drug.Elements().Where(x => x.Name.LocalName == "state").FirstOrDefault()).Trim();
                int zd = state.Length;
                string synthesis_reference = ((string)drug.Elements().Where(x => x.Name.LocalName == "synthesis-reference").FirstOrDefault());
                int ze = synthesis_reference.Length;
                string indication = ((string)drug.Elements().Where(x => x.Name.LocalName == "indication").FirstOrDefault());
                int zf = indication.Length;
                string pharmacodynamics = ((string)drug.Elements().Where(x => x.Name.LocalName == "pharmacodynamics").FirstOrDefault());
                int zg = pharmacodynamics.Length;
                string mechanism_of_action = ((string)drug.Elements().Where(x => x.Name.LocalName == "mechanism-of-action").FirstOrDefault());
                int zh = mechanism_of_action.Length;
                string toxicity = ((string)drug.Elements().Where(x => x.Name.LocalName == "toxicity").FirstOrDefault());
                int zi = toxicity.Length;
                string metabolism = ((string)drug.Elements().Where(x => x.Name.LocalName == "metabolism").FirstOrDefault());
                int zj = metabolism.Length;
                string absorption = ((string)drug.Elements().Where(x => x.Name.LocalName == "absorption").FirstOrDefault());
                int zk = absorption.Length;
                string half_life = ((string)drug.Elements().Where(x => x.Name.LocalName == "half-life").FirstOrDefault());
                int zl = half_life.Length;
                string protein_binding = ((string)drug.Elements().Where(x => x.Name.LocalName == "protein-binding").FirstOrDefault());
                int zm = protein_binding.Length;
                string route_of_elimination = ((string)drug.Elements().Where(x => x.Name.LocalName == "route-of-elimination").FirstOrDefault());
                int zn = route_of_elimination.Length;
                string volume_of_distribution = ((string)drug.Elements().Where(x => x.Name.LocalName == "volume-of-distribution").FirstOrDefault());
                int zo = volume_of_distribution.Length;
                string clearance = ((string)drug.Elements().Where(x => x.Name.LocalName == "clearance").FirstOrDefault());
                int zp = clearance.Length;
                drugCmd.Parameters["@Type"].Value = dType;
                drugCmd.Parameters["@Created"].Value = created;
                drugCmd.Parameters["@Updated"].Value = updated;
                drugCmd.Parameters["@ID"].Value = primaryID;
                drugCmd.Parameters["@Name"].Value = name;
                drugCmd.Parameters["@Description"].Value = description;
                drugCmd.Parameters["@Case_Number"].Value = case_number;
                drugCmd.Parameters["@Unii"].Value = unii;
                drugCmd.Parameters["@State"].Value = state;
                drugCmd.Parameters["@Synthesis_Reference"].Value = synthesis_reference;
                drugCmd.Parameters["@Indication"].Value = indication;
                drugCmd.Parameters["@Pharmacodynamics"].Value = pharmacodynamics;
                drugCmd.Parameters["@Mechanism_of_Action"].Value = mechanism_of_action;
                drugCmd.Parameters["@Toxicity"].Value = toxicity;
                drugCmd.Parameters["@Metabolism"].Value = metabolism;
                drugCmd.Parameters["@Absorption"].Value = absorption;
                drugCmd.Parameters["@Half_Life"].Value = half_life;
                drugCmd.Parameters["@Protein_Binding"].Value = protein_binding;
                drugCmd.Parameters["@Route_of_Elimination"].Value = route_of_elimination;
                drugCmd.Parameters["@Volume_of_Distribution"].Value = volume_of_distribution;
                drugCmd.Parameters["@Clearance"].Value = clearance;
                drugCmd.ExecuteNonQuery();
            }
            public void AddArticles(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("article")))
                {
                    string pubmed_id = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "pubmed-id").FirstOrDefault());
                    string citation = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "citation").FirstOrDefault());
                    articleCmd.Parameters["@ID"].Value = id;
                    articleCmd.Parameters["@Pubmed_ID"].Value = pubmed_id;
                    articleCmd.Parameters["@Citation"].Value = citation;
                    articleCmd.ExecuteNonQuery();
                }
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("link")))
                {
                    string title = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "title").FirstOrDefault());
                    string url = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "url").FirstOrDefault());
                    linkCmd.Parameters["@ID"].Value = id;
                    linkCmd.Parameters["@Title"].Value = title;
                    linkCmd.Parameters["@URL"].Value = url;
                    linkCmd.ExecuteNonQuery();
                }
            }
            public void AddInteractions(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement interaction in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("drug-interaction")))
                {
                    string interactionID = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "drugbank-id").FirstOrDefault()).Trim();
                    string description = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "description").FirstOrDefault());
                    interactionCmd.Parameters["@ID"].Value = id;
                    interactionCmd.Parameters["@Interaction_ID"].Value = interactionID;
                    interactionCmd.Parameters["@Description"].Value = description;
                    interactionCmd.ExecuteNonQuery();
                }
            }
            public void AddProducts(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement product in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("product")))
                {
                    string name = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "name").FirstOrDefault()).Trim();
                    string labeller = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "labeller").FirstOrDefault()).Trim();
                    string ndc_id = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ndc-id").FirstOrDefault());
                    string ndc_product_code = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ndc-product-code").FirstOrDefault());
                    string dpd_id = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "dpd-id").FirstOrDefault());
                    string ema_product_code = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ema-product-code").FirstOrDefault());
                    string ema_ma_number = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ema-ma-number").FirstOrDefault());
                    string started_marketing_onStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "started-marketing-on").FirstOrDefault());
                    string ended_marketing_onStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ended-marketing-on").FirstOrDefault());
                    string dosage_form = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "dosage-form").FirstOrDefault());
                    string strength = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "strength").FirstOrDefault());
                    string route = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "route").FirstOrDefault());
                    string fda_application_number = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "fda-application-number").FirstOrDefault());
                    string genericStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "generic").FirstOrDefault());
                    byte? generic = string.IsNullOrEmpty(genericStr) ? null : ((genericStr == "true") ? (byte?)1 : (byte?)0);
                    string over_the_counterStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "over-the-counter").FirstOrDefault());
                    byte? over_the_counter = string.IsNullOrEmpty(over_the_counterStr) ? null : ((over_the_counterStr == "true") ? (byte?)1 : (byte?)0);
                    string approvedStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "approved").FirstOrDefault());
                    byte? approved = string.IsNullOrEmpty(approvedStr) ? null : ((approvedStr == "true") ? (byte?)1 : (byte?)0);
                    string country = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "country").FirstOrDefault());
                    string source = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "source").FirstOrDefault());
                    productCmd.Parameters["@ID"].Value = id;
                    productCmd.Parameters["@Name"].Value = name;
                    productCmd.Parameters["@Labeller"].Value = labeller;
                    productCmd.Parameters["@NDC_ID"].Value = ndc_id;
                    productCmd.Parameters["@NDC_Product_Code"].Value = ndc_product_code;
                    productCmd.Parameters["@DPD_ID"].Value = dpd_id;
                    productCmd.Parameters["@EMA_Product_Code"].Value = ema_product_code;
                    productCmd.Parameters["@EMA_MA_Number"].Value = ema_ma_number;
                    if (!string.IsNullOrEmpty(started_marketing_onStr))
                    {
                        productCmd.Parameters["@Started_Marketing_On"].Value = DateTime.Parse(started_marketing_onStr);
                    }
                    else
                    {
                        productCmd.Parameters["@Started_Marketing_On"].Value = new DateTime();
                    }
                    if (!string.IsNullOrEmpty(ended_marketing_onStr))
                    {
                        productCmd.Parameters["@Ended_Marketing_On"].Value = DateTime.Parse(ended_marketing_onStr);
                    }
                    else
                    {
                        productCmd.Parameters["@Ended_Marketing_On"].Value = new DateTime();
                    }
                    productCmd.Parameters["@Dosage_Form"].Value = dosage_form;
                    productCmd.Parameters["@Strength"].Value = strength;
                    productCmd.Parameters["@Route"].Value = route;
                    productCmd.Parameters["@FDA_Application_Number"].Value = fda_application_number;
                    productCmd.Parameters["@Generic"].Value = generic;
                    productCmd.Parameters["@Over_The_Counter"].Value = over_the_counter;
                    productCmd.Parameters["@Approved"].Value = approved;
                    productCmd.Parameters["@Country"].Value = country;
                    productCmd.Parameters["@Source"].Value = source;
                    productCmd.ExecuteNonQuery();
                }
            }
        }
    }
