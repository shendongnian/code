    <%= Html.Grid(ViewData["PossibleValues"] as IEnumerable<FFFF>).Columns(column =>
                               {
                                column.For(gf => gf.Value).Named("Value");
                            }).Empty("Sorry no data.")%>
                           <%= Html.Pager((IPagination)(ViewData["PossibleValues"] as IEnumerable<FFFF>))%>
