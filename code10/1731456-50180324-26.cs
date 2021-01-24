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
            const string INSERT_DRUG_LINK =
                "INSERT INTO [DrugBank].[dbo].[Links] (" +
                "[ID],[Title],[URL])" +
                " VALUES " +
                "(@ID,@Title, @URL)";
            const string INSERT_DRUG_ARTICLE =
                "INSERT INTO [DrugBank].[dbo].[Articles] (" +
                "[ID],[Pubmed ID],[Citation])" +
                " VALUES " +
                "(@ID,@Pubmed_ID, @Citation)";
            const string INSERT_DRUG_INTERACTION =
                "INSERT INTO [DrugBank].[dbo].[Interactions] (" +
                "[ID],[Interaction ID],[Description])" +
                " VALUES " +
                "(@ID,@Interaction_ID, @Description)";
            const string INSERT_DRUG_ID =
                "INSERT INTO [DrugBank].[dbo].[IDs] (" +
                "[ID],[ALT ID])" +
                " VALUES " +
                "(@ID, @ALT_ID)";
            const string INSERT_DRUG_PRODUCT =
                "INSERT INTO [DrugBank].[dbo].[Products] (" +
                "[ID],[Name],[Labeller], [NDC ID], [NDC Product Code], [DPD ID]," +
                "[EMA Product Code],[EMA MA Number],[Started Marketing On], [Ended Marketing On], [Dosage Form]," +
                "[Strength],[Route],[FDA Application Number],[Generic],[Over the Counter],[Approved],[Country],[Source])" +
                " VALUES " +
                "(@ID,@Name,@Labeller, @NDC_ID, @NDC_Product_Code,@DPD_ID," +
                "@EMA_Product_Code,@EMA_MA_Number,@Started_Marketing_On, @Ended_Marketing_On, @Dosage_Form," +
                "@Strength,@Route,@FDA_Application_Number,@Generic,@Over_the_Counter,@Approved,@Country,@Source)";
            const string INSERT_DRUG_MIXTURE =
                "INSERT INTO [DrugBank].[dbo].[Mixtures] (" +
                "[ID], [Name] , [ingredients])" +
                " VALUES " +
                "(@ID, @Name, @ingredients)";
            const string INSERT_DRUG_PACKAGER =
                 "INSERT INTO [DrugBank].[dbo].[Packagers] (" +
                 "[ID], [Name], [URL])" +
                 " VALUES " +
                 "(@ID, @Name, @URL)";
            const string INSERT_DRUG_PRICE = 
                 "INSERT INTO [DrugBank].[dbo].[Prices] (" +
                 "[ID], [Description], [Cost], [Currency], [Unit])" +
                 " VALUES " +
                 "(@ID, @Description, @Cost, @Currency, @Unit)";
            const string INSERT_DRUG_CATEGORY =
                "INSERT INTO [DrugBank].[dbo].[Categories] (" +
                "[ID], [Category], [Mesh ID])" +
                " VALUES " +
                "(@ID, @Category, @Mesh_ID)";
            const string INSERT_DRUG_ORGANISM =
                "INSERT INTO [DrugBank].[dbo].[Organisms] (" +
                "[ID], [Organism])" +
                " VALUES " +
                "(@ID, @Organism)";
            const string INSERT_DRUG_PATENT =
                "INSERT INTO [DrugBank].[dbo].[Patents] (" +
                "[ID], [Number], [Country], [Approved], [Expires], [Pediatric Extension]) " +
                " VALUES " +
                "(@ID, @Number, @Country, @Approved, @Expires, @Pediatric_Extension) ";
            const string INSERT_DRUG_SEQUENCE =
                "INSERT INTO [DrugBank].[dbo].[Sequences] (" +
                "[ID], [Format], [Type], [Sequence])" +
                " VALUES " +
                "(@ID, @Format, @Type, @Sequence)";
            const string INSERT_DRUG_PROPERTY =
                "INSERT INTO [DrugBank].[dbo].[Properties] (" +
                "[ID], [Kind], [Value], [Source])" +
                " VALUES " +
                "(@ID, @Kind, @Value, @Source)";
            const string INSERT_DRUG_IDENTIFIER =
                "INSERT INTO [DrugBank].[dbo].[Identifiers] (" +
                "[ID], [Resource], [Identifier])" +
                " VALUES " +
                "(@ID, @Resource, @Identifier)";
            const string INSERT_DRUG_ENZYM =
                "INSERT INTO [DrugBank].[dbo].[Enzymes] (" +
                "[ID], [UniprotID])" +
                " VALUES " +
                "(@ID, @UniprotID)";
            SqlCommand productCmd = null;
            SqlCommand interactionCmd = null;
            SqlCommand articleCmd = null;
            SqlCommand linkCmd = null;
            SqlCommand drugCmd = null;
            SqlCommand idCmd = null;
            SqlCommand mixtureCmd = null;
            SqlCommand packagerCmd = null;
            SqlCommand priceCmd = null;
            SqlCommand categoryCmd = null;
            SqlCommand organismCmd = null;
            SqlCommand patentCmd = null;
            SqlCommand sequenceCmd = null;
            SqlCommand propertyCmd = null;
            SqlCommand identifierCmd = null;
            SqlCommand enzymCmd = null;
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
                productCmd.Parameters.Add("@Over_the_Counter", SqlDbType.Bit);
                productCmd.Parameters.Add("@Approved", SqlDbType.Bit);
                productCmd.Parameters.Add("@Country", SqlDbType.VarChar, 20);
                productCmd.Parameters.Add("@Source", SqlDbType.VarChar, 20);
                mixtureCmd = new SqlCommand(INSERT_DRUG_MIXTURE, conn);
                mixtureCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                mixtureCmd.Parameters.Add("@Name", SqlDbType.VarChar, 64);
                mixtureCmd.Parameters.Add("@Ingredients", SqlDbType.VarChar, 64);
                packagerCmd = new SqlCommand(INSERT_DRUG_PACKAGER, conn);
                packagerCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                packagerCmd.Parameters.Add("@Name", SqlDbType.VarChar, 64);
                packagerCmd.Parameters.Add("@URL", SqlDbType.VarChar, 64);
                priceCmd = new SqlCommand(INSERT_DRUG_PRICE, conn);
                priceCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                priceCmd.Parameters.Add("@Description", SqlDbType.VarChar, 128);
                priceCmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                priceCmd.Parameters.Add("@Currency", SqlDbType.VarChar,20);
                priceCmd.Parameters.Add("@Unit", SqlDbType.VarChar, 20);
                categoryCmd = new SqlCommand(INSERT_DRUG_CATEGORY, conn);
                categoryCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                categoryCmd.Parameters.Add("@Category", SqlDbType.VarChar, 128);
                categoryCmd.Parameters.Add("@Mesh_ID", SqlDbType.VarChar, 20);
                organismCmd = new SqlCommand(INSERT_DRUG_ORGANISM, conn);
                organismCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                organismCmd.Parameters.Add("@Organism", SqlDbType.VarChar, 128);
                patentCmd = new SqlCommand(INSERT_DRUG_PATENT, conn);
                patentCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                patentCmd.Parameters.Add("@Number", SqlDbType.VarChar, 20);
                patentCmd.Parameters.Add("@Country", SqlDbType.VarChar, 20);
                patentCmd.Parameters.Add("@Approved", SqlDbType.DateTime2);
                patentCmd.Parameters.Add("@Expires", SqlDbType.DateTime2);
                patentCmd.Parameters.Add("@Pediatric_Extension", SqlDbType.Bit);
                sequenceCmd = new SqlCommand(INSERT_DRUG_SEQUENCE, conn);
                sequenceCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                sequenceCmd.Parameters.Add("@Format", SqlDbType.VarChar, 20);
                sequenceCmd.Parameters.Add("@Sequence", SqlDbType.VarChar);
                sequenceCmd.Parameters.Add("@Type", SqlDbType.VarChar, 20);
                propertyCmd = new SqlCommand(INSERT_DRUG_PROPERTY, conn);
                propertyCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                propertyCmd.Parameters.Add("@Kind", SqlDbType.VarChar, 20);
                propertyCmd.Parameters.Add("@Value", SqlDbType.VarChar, 20);
                propertyCmd.Parameters.Add("@Source", SqlDbType.VarChar, 20);
                identifierCmd = new SqlCommand(INSERT_DRUG_IDENTIFIER, conn);
                identifierCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                identifierCmd.Parameters.Add("@Resource", SqlDbType.VarChar, 64);
                identifierCmd.Parameters.Add("@Identifier", SqlDbType.VarChar, 64);
                enzymCmd = new SqlCommand(INSERT_DRUG_ENZYM, conn);
                enzymCmd.Parameters.Add("@ID", SqlDbType.VarChar, 20);
                enzymCmd.Parameters.Add("@UniprotID", SqlDbType.VarChar, 20);
     
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
                        AddMixtures(conn, drug, primaryID);
                        AddPackagers(conn, drug, primaryID);
                        AddPrices(conn, drug, primaryID);
                        AddCategories(conn, drug, primaryID);
                        AddOrganisms(conn, drug, primaryID);
                        AddPatents(conn, drug, primaryID);
                        AddSequences(conn, drug, primaryID);
                        AddProperties(conn, drug, primaryID);
                        AddIdentifiers(conn, drug, primaryID);
                        AddEnzymes(conn, drug, primaryID);
                    }
                }
            }
