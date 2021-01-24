    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using RestaurantDataModel.Data.Requests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    namespace ExampleDataModel.Data
    {
    public class CustomDataTableEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var allValues = bindingContext.HttpContext.Request.Query;
            DataTableOptions DTOs = new DataTableOptions {
                Draw = allValues.FirstOrDefault(a => a.Key == "draw").Value,
                Start = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "start").Value),
                Length = Convert.ToInt32(allValues.FirstOrDefault(a => a.Key == "length").Value)
            };
            
            if (allValues.Any(a => a.Key.Length > 9 && a.Key.Substring(0, 9).Contains("columns")))
            {
                var myListIndex = 0;
                var myListIndexComparer = 0;
                var allColumns = allValues.Where(a => a.Key.Length > 9 && a.Key.Substring(0, 9).Contains("columns")).ToList();
                DataTableColumn DTC = new DataTableColumn();
                DataTableColumnSearch DTCS = new DataTableColumnSearch();
                DTOs.columns = new List<DataTableColumn>();
                foreach (var column in allColumns)
                {
                    var perColumnArray = column.Key.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    var rawIndex = perColumnArray[1];
                    if (!int.TryParse(rawIndex, out myListIndex))
                    {
                        return Task.CompletedTask;
                    }
                    if (myListIndexComparer != myListIndex)
                    {
                        DTC.search = DTCS;
                        DTOs.columns.Add(DTC);
                        DTC = new DataTableColumn();
                        DTCS = new DataTableColumnSearch();
                    }
                    myListIndexComparer = myListIndex;
                    switch (perColumnArray[2])
                    {
                        case "data":
                            DTC.data = column.Value;
                            break;
                        case "name":
                            DTC.name = column.Value;
                            break;
                        case "searchable":
                            DTC.searchable = String.IsNullOrWhiteSpace(column.Value) ? false : Convert.ToBoolean(column.Value);
                            break;
                        case "orderable":
                            DTC.orderable = String.IsNullOrWhiteSpace(column.Value) ? false : Convert.ToBoolean(column.Value);
                            break;
                        case "search":
                            if (perColumnArray[3] == "regex")
                            {
                                DTCS.regex = String.IsNullOrWhiteSpace(column.Value) ? false : Convert.ToBoolean(column.Value);
                            }
                            if (perColumnArray[3] == "value")
                            {
                                DTCS.value = column.Value;
                            }
                            break;
                    }
                    if(allColumns.IndexOf(column) == allColumns.IndexOf(allColumns.Last()))
                    {
                        DTC.search = DTCS;
                        DTOs.columns.Add(DTC);
                    }
                }
            }
            if (allValues.Any(a => a.Key.Length > 7 && a.Key.Substring(0, 7).Contains("order")))
            {
                var myListIndex = 0;
                var myListIndexComparer = 0;
                var allOrders = allValues.Where(a => a.Key.Length > 7 && a.Key.Substring(0, 7).Contains("order")).ToList();
                DataTableColumnOrder DTCO = new DataTableColumnOrder();
                DTOs.order = new List<DataTableColumnOrder>();
                foreach (var order in allOrders)
                {
                    var perColumnArray = order.Key.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    var rawIndex = perColumnArray[1];
                    if (!int.TryParse(rawIndex, out myListIndex))
                    {
                        return Task.CompletedTask;
                    }
                    if (myListIndexComparer != myListIndex)
                    {
                        DTOs.order.Add(DTCO);
                        DTCO = new DataTableColumnOrder();
                    }
                    myListIndexComparer = myListIndex;
                    switch (perColumnArray[2])
                    {
                        case "column":
                            DTCO.Column = Convert.ToInt32(order.Value);
                            break;
                        case "dir":
                            DTCO.Dir = order.Value;
                            break;
                    }
                    if(allOrders.IndexOf(order) == allOrders.IndexOf(allOrders.Last()))
                    {
                        DTOs.order.Add(DTCO);
                    }
                }
            }
            if (allValues.Any(a => a.Key.Length > 7 && a.Key.Substring(0, 8).Contains("search")))
            {
                var allSearches = allValues.Where(a => a.Key.Length > 8 && a.Key.Substring(0, 8).Contains("search")).ToList();
                DataTableColumnSearch DTCS = new DataTableColumnSearch();
                DTOs.search = new DataTableColumnSearch();
                foreach (var search in allSearches)
                {
                    var perColumnArray = search.Key.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    switch (perColumnArray[1])
                    {
                        case "value":
                            DTCS.value = search.Value;
                            break;
                        case "regex":
                            DTCS.regex = String.IsNullOrWhiteSpace(search.Value) ? false : Convert.ToBoolean(search.Value);
                            break;
                    }
                    if(allSearches.IndexOf(search) == allSearches.IndexOf(allSearches.Last()))
                    {
                        DTOs.search = DTCS;
                    }
                }
            }
            bindingContext.Result = ModelBindingResult.Success(DTOs);
            return Task.CompletedTask;
        }
    }
    
    }
