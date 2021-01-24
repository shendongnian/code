    public Dictionary<int, string> testC([FromBody]Dictionary<string,string> demoData)
        {
            var getRules = AsDynamic(App.Data["Rules"]);
            // Link_group Link_datakey  Link_datavalue Link_operator
            
            var getRuleGroups = AsDynamic(App.Data["RuleGroups"]);
            // Link_group Link_product Link_type
            
            var getProducts = AsDynamic(App.Data["Products"]);
            // Product_id Product_name
            
            
            Dictionary<int, string> testdict = new Dictionary<int, string>();
            
            var product = 0;
            var rulegetcount = 0;
            var rulesetcount = 0;
            int tryparsedataint;
            bool tryparsedatabool;
            int tryparsevalueint;
            bool tryparsevaluebool;
            
            foreach(var rg in getRuleGroups.Where(t => t.Link_type == "add")){
                rulegetcount = getRules.Where(r => r.Link_group == rg.Link_group).Count();
                rulesetcount = 0;
                foreach(var r in getRules.Where(r => r.Link_group == rg.Link_group)){
                    if (demoData.ContainsKey(r.Link_datakey)) {
                        if(r.Link_operator == "==") {
                            if (demoData[r.Link_datakey] == r.Link_datavalue) {
                                rulesetcount ++;
                            }
                        } else if(r.Link_operator == "<") {
                            tryparsedatabool = Int32.TryParse(demoData[r.Link_datakey], out tryparsedataint);
                            tryparsevaluebool = Int32.TryParse(r.Link_datavalue, out tryparsevalueint);
                            if(tryparsedatabool && tryparsevaluebool) {
                                if (tryparsedataint < tryparsevalueint) {
                                    rulesetcount ++;
                                }
                            }
                        } else if(r.Link_operator == ">") {
                            tryparsedatabool = Int32.TryParse(demoData[r.Link_datakey], out tryparsedataint);
                            tryparsevaluebool = Int32.TryParse(r.Link_datavalue, out tryparsevalueint);
                            if(tryparsedatabool && tryparsevaluebool) {
                                if (tryparsedataint > tryparsevalueint) {
                                    rulesetcount ++;
                                }
                            }
                        } else if(r.Link_operator == "!=") {
                            if (demoData[r.Link_datakey] != r.Link_datavalue) {
                                rulesetcount ++;
                            }
                        }
                    }
                }
                
                if (rulegetcount == rulesetcount) {
                    product = Convert.ToInt32(rg.Link_product);
                    if (!testdict.ContainsKey(product)) {
                        testdict.Add(product, getPropList.Where(i => i.Product_id == rg.Link_product).First().Product_name);
                    }
                }
            }
            
            return testdict;
        }
