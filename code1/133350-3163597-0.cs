    var select = webBrowser.Document.GetElementById("ddlProyectos");
                        mshtml.HTMLSelectElement cbProyectos = select.DomElement as mshtml.HTMLSelectElement;
    
    
                        var total = cbProyectos.length;
                        for (var i= 0; i < total; i++)
                        {
                            cbProyectos.selectedIndex = i;
                            if (cbProyectos.value.Contains("13963"))
                            {
                                break;
                            }
    
                        }
                        //cbProyectos.selectedIndex = 4;
                        select.InvokeMember("onchange");
