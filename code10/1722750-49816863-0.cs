    private IEnumerable<Appointment> GetAllSafeAppointments(Folder calendar) {
                ItemView view = new ItemView(512);
    
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
    
                SearchFilter filter = new SearchFilter.SearchFilterCollection(LogicalOperator.And,
                                                                              new SearchFilter.IsEqualTo(SafeAppointmentFlag, true));
    
                while(true) {
                    var results = SendExchangeRequest(() => calendar.FindItems(filter, view));
    
                    foreach(var r in results.OfType<Appointment>())
                        yield return r;
    
                    if(!results.MoreAvailable)
                        break;
    
                    view.Offset = results.NextPageOffset.Value;
                }
            }
