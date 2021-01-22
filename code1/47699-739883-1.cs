    using System;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Collections.Specialized;
    using System.Text;
    namespace YourDebug.Name.Space
    {
    /// <summary>
    ///Debugs passed objects and returns ready formatted html with the objects values
    /// </summary>
    public class HtmlDebugger
    {
        public static string DumpDataSet(string msg, DataSet ds)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<p> START " + msg + "</p>");
            if (ds == null)
                return msg + " null ds passed ";
            if (ds.Tables == null || ds.Tables.Count == 0)
                return msg + " no tables in ds ";
                sb.Append("<p> DEBUG START --- " + msg + "</p>");            
                foreach (System.Data.DataTable dt in ds.Tables)
                {
                    sb.Append("================= My TableName is  " +
                    dt.TableName + " ========================= START");
                    sb.Append("<table>\n");
                    int colNumberInRow = 0;
                    foreach (System.Data.DataColumn dc in dt.Columns)
                    {
                        sb.Append(" <th>  ");
                        sb.Append(" |" + colNumberInRow + "| ");
                        sb.Append(dc.ColumnName + " </th> ");
                        colNumberInRow++;
                    } //eof foreach (DataColumn dc in dt.Columns)
                    int rowNum = 0;
                    foreach (System.Data.DataRow dr in dt.Rows)
                    {
                        string strBackGround = String.Empty;
                        if (rowNum% 2 == 0)
                            strBackGround = " bgcolor=\"#D2D2D2\" "; 
                    
                        sb.Append("\n " + rowNum + "<tr " + strBackGround + " >");
                        int colNumber = 0;
                        foreach (System.Data.DataColumn dc in dt.Columns)
                        {
                            sb.Append("<td> |" + colNumber + "| ");
                            sb.Append(dr[dc].ToString() + " </td>");
                            colNumber++;
                        } //eof foreach (DataColumn dc in dt.Columns)
                        rowNum++;
                        sb.Append("</tr>");
                    }    //eof foreach (DataRow dr in dt.Rows)
                    sb.Append(" \n");
                    sb.Append("</table>");
                }    //eof foreach (DataTable dt in sb.Append.Tables)
                sb.Append("<p> DEBUG END--- " + msg + "</p>");            
                return sb.ToString();
            
        }//eof method  
        
        public static string DumpMsgList(string msg, 
        System.Collections.Generic.List<GenApp.Dh.Msg> listMsgs)
        {
            
            System.Text.StringBuilder echo = new System.Text.StringBuilder();
            if (listMsgs == null)
                return "null listMsgs passed for debugging ";
            if (listMsgs.Count == 0)
                return "listMsgs.Count == 0"; 
            echo.Append("<table>");
            for (int msgCounter = 0; msgCounter < listMsgs.Count; msgCounter++)
            {
                GenApp.Dh.Msg objMsg = listMsgs[msgCounter];
                string strBackGround = String.Empty;
                if (msgCounter % 2 == 0)
                    strBackGround = " bgcolor=\"#D2D2D2\" "; 
                echo.Append("<tr" + strBackGround + ">");
                echo.Append("<td>msg.MsgKey</td> <td> " + objMsg.MsgKey + "</td>");
                echo.Append("<td>msg.MsgId</td><td>" + objMsg.MsgId + "</td>");
                echo.Append("</tr>");
            } //eof foreach 
            echo.Append("</table>");
            return echo.ToString();
        
        } //eof method 
        public static string DumpIDataReader(string msg, IDataReader rdr)
        {
            StringBuilder sb = new StringBuilder();
            
            if (rdr == null)
                return " <p> IDataReader rds is null </p>";
                sb.Append("DEBUG START ---" + msg);
                sb.Append("<table>");
                int counter = 0; 
                while (rdr.Read() )
                {
                    string strBackGround = String.Empty;
                    if (counter % 2 == 0)
                        strBackGround = " bgcolor=\"#3EBDE8\" "; 
                    sb.Append("<tr" + strBackGround + ">");
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        sb.Append("<td>");
                        sb.Append(rdr[i].ToString() + " ");
                        sb.Append("<td>");
                    } //eof for 
                    sb.Append("</br>");
                    sb.Append("</tr>");
                    counter++; 
                }
                sb.Append("<table>");
                sb.Append("DEBUG END ---" + msg);
                return sb.ToString();        
        } //eof method 
        public static string DumpListDictionary(string msg , 
        ListDictionary list)
        {
          if (list == null)
            return "<p> null list passed </p>";
          if (list.Count == 0)
            return "<p> list.Count = 0 </p> "; 
              System.Text.StringBuilder sb = new System.Text.StringBuilder();
              sb.Append("<p> START DUMP " + msg + " </p>");
              sb.Append("<table>");
              int counter = 0; 
              foreach (object key in list.Keys)
              {
                string strBackGround = String.Empty;
                if (counter % 2 == 0)
                  strBackGround = " bgcolor=\"#D2D2D2\" ";
                sb.Append("<tr" + strBackGround + "><td> key - </td><td> " + 
                key.ToString());
                sb.Append("</td><td>===</td><td>value - </td><td> " + list[key] + 
                "</td></br></tr>");
                counter++;
              } //eof foreach 
              sb.Append("</table>");
              sb.Append("<p> END DUMP " + msg + " </p>");
          return sb.ToString();
        } //eof method 
    } //eof class 
