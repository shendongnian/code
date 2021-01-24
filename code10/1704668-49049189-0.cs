    HttpResponse Response = HttpContext.Current.Response;
    string csv = string.Empty;
    csv += "UTI code, Counterparty, Maturity, Volume, Evaluation Date";
    csv += "\r\n";
    string _uti, _counterparty;
    DateTime _maturity, _date;
    decimal _volume;
    for (int i = 0; i < list.Count; i++)
            {
                if (list[i].uti_cd == null) _uti = "-"; else _uti = list[i].uti_cd;
                if (list[i].namecounterparty == null) _counterparty = "-"; else _counterparty = list[i].namecounterparty;
                if (list[i].maturity == null) _maturity = DateTime.MinValue.Date; else _maturity = list[i].maturity;
                if (list[i].contract_volume == 0) _volume = 0; else _volume = list[i].contract_volume;
                if (list[i].evaluation_date == null) _date = DateTime.MinValue.Date; else _date = list[i].evaluation_date;
                csv += _uti + ",";
                csv += _counterparty + ",";
                csv += _maturity + ",";
                csv += _volume + ",";
                csv += _date;
                csv += "\r\n";
            }
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();
