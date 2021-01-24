    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Linq;
    					
    public class Program
    {
    	public class ACOParticipantData 
    	{
    		public Header Header { get; set; }
    		public Participant[] Participants { get; set; }
    	}
    	
    	public class Header 
    	{
    		public string HeaderCode { get; set; }
    		public string FileCreationDate { get; set; }
    		public string ACOProgCode { get; set; }
    	}
    	
    	public class Participant 
    	{
    		public string ACO_ID { get; set; }
    		public string TIN { get; set; }
    		public string Old_TIN { get; set; }
    		public string Org_NPI { get; set; }
    		public string Ind_NPI { get; set; }
    		public string CCN { get; set; }
    		public string PRG_Eff_Dt { get; set; }
    		public string PRG_Term_Dt { get; set; }
    	}
    	
    	public class Trailer 
    	{
    		public string TrailerCode { get; set; }
    		public string FileCreationDate { get; set; }
    		public string RecordCount { get; set; }
    	}
    
    	public static void Main()
    	{
    		var xmlString = @"<ACOParticipantData>
    		  <Header>
    			<HeaderCode>HDR_PFPRVDR</HeaderCode>
    			<FileCreationDate>20160101</FileCreationDate>
    			<ACOProgCode>21</ACOProgCode>
    		  </Header>
    		  <Participants>
    			<Participant>
    			  <ACO_ID>V199</ACO_ID>
    			  <TIN>123456789</TIN>
    			  <Old_TIN>987654321</Old_TIN>
    			  <Org_NPI>1234567890</Org_NPI>
    			  <Ind_NPI>1234567890</Ind_NPI>
    			  <CCN>123456</CCN>
    			  <PRG_Eff_Dt>20160101</PRG_Eff_Dt>
    			  <PRG_Term_Dt>20161231</PRG_Term_Dt>
    			</Participant>
    			<Participant>
    			  <ACO_ID>V199</ACO_ID>
    			  <TIN>123456780</TIN>
    			  <Old_TIN>987654321</Old_TIN>
    			  <Org_NPI>1234567890</Org_NPI>
    			  <Ind_NPI>1234567890</Ind_NPI>
    			  <CCN>123456</CCN>
    			  <PRG_Eff_Dt>20160101</PRG_Eff_Dt>
    			  <PRG_Term_Dt>20161231</PRG_Term_Dt>
    			</Participant>
    		  </Participants>
    		  <Trailer>
    			<TrailerCode>TRL_PFPRVDR</TrailerCode>
    			<FileCreationDate>20160101</FileCreationDate>
    			<RecordCount>1</RecordCount>
    		  </Trailer>
    		</ACOParticipantData>";
    		
    		var serializer = new XmlSerializer(typeof(ACOParticipantData));
    
    		ACOParticipantData obj = null;
    		using (var reader = new StringReader(xmlString))
    		{
    			obj = (ACOParticipantData)serializer.Deserialize(reader);
    		}
    		
    		if (obj == null) 
    		{
    			return;
    		}
    		
    		foreach (var tin in obj.Participants.Select(x => x.TIN)) 
    		{
    			Console.WriteLine(tin);
    		}
    	}
    }
