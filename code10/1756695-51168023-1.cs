    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Net;
	using System.IO;
	using System.Text;
	using System.Xml;
	using System.Data;
	namespace ms_tempo
	{
		public partial class Default : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fakerestapi.azurewebsites.net/api/Authors");
				httpWebRequest.ContentType = "application/xml";
				HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				DataSet dataSet = new DataSet();
				if (webResponse.StatusCode == HttpStatusCode.OK)
				{
					Stream responseStream = webResponse.GetResponseStream();
					dataSet.ReadXml(responseStream);
					gv.DataSource = dataSet.Tables[0];
					gv.DataBind();
				}
			}
		}
	}
