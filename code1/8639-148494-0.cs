    using System.Net;
    using System.Text;
    using System;
    
    namespace RightNowSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string serviceUrl = "http://<your_domain>/cgi-bin/<your_interface>.cfg/php/xml_api/parse.php";
                WebClient webClient = new WebClient();
                string requestXml = 
    @"<connector>
    <function name=""ans_get"">
    <parameter name=""args"" type=""pair"">
    <pair name=""id"" type=""integer"">33</pair>
    <pair name=""sub_tbl"" type='pair'>
    <pair name=""tbl_id"" type=""integer"">164</pair>
    </pair>
    </parameter>
    </function>
    </connector>";
    
                string secString = "";
                string postData = string.Format("xml_doc={0}, sec_string={1}", requestXml, secString);
                byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
    
                byte[] responseDataBytes = webClient.UploadData(serviceUrl, "POST", postDataBytes);
                string responseData = Encoding.UTF8.GetString(responseDataBytes);
     
                Console.WriteLine(responseData);
            }
        }
    }
