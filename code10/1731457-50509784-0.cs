           public void AddDrug(SqlConnection conn, XElement drug, string primaryID)
            {
                string dType = ((string)drug.Attribute("type")).Trim();
                DateTime created = (DateTime)drug.Attribute("created");
                DateTime updated = (DateTime)drug.Attribute("updated");
                List<XElement> drugbank_ids = drug.Elements().Where(x => (x.Name.LocalName == "drugbank-id") && (x.Attribute("primary") != null)).ToList();
                string name = ((string)drug.Elements().Where(x => x.Name.LocalName == "name").FirstOrDefault()).Trim();
                foreach (string drugbank_id in drugbank_ids)
                {
                    idCmd.Parameters["@ID"].Value = primaryID;
                    idCmd.Parameters["@ALT_ID"].Value = drugbank_id;
                    idCmd.ExecuteNonQuery();
                }
                string description = ((string)drug.Elements().Where(x => x.Name.LocalName == "description").FirstOrDefault()).Trim();
                int za = description.Length;
                string case_number = ((string)drug.Elements().Where(x => x.Name.LocalName == "cas-number").FirstOrDefault());
                int zb = case_number.Length;
                string unii = ((string)drug.Elements().Where(x => x.Name.LocalName == "unii").FirstOrDefault());
                int zc = unii.Length;
                string state = (drug.Elements().Where(x => x.Name.LocalName == "state").FirstOrDefault() == null) ? "" : ((string)drug.Elements().Where(x => x.Name.LocalName == "state").FirstOrDefault()).Trim();
                int zd = state.Length;
                string synthesis_reference = ((string)drug.Elements().Where(x => x.Name.LocalName == "synthesis-reference").FirstOrDefault());
                int ze = synthesis_reference.Length;
                string indication = ((string)drug.Elements().Where(x => x.Name.LocalName == "indication").FirstOrDefault());
                int zf = indication.Length;
                string pharmacodynamics = ((string)drug.Elements().Where(x => x.Name.LocalName == "pharmacodynamics").FirstOrDefault());
                int zg = pharmacodynamics.Length;
                string mechanism_of_action = ((string)drug.Elements().Where(x => x.Name.LocalName == "mechanism-of-action").FirstOrDefault());
                int zh = mechanism_of_action.Length;
                string toxicity = ((string)drug.Elements().Where(x => x.Name.LocalName == "toxicity").FirstOrDefault());
                int zi = toxicity.Length;
                string metabolism = ((string)drug.Elements().Where(x => x.Name.LocalName == "metabolism").FirstOrDefault());
                int zj = metabolism.Length;
                string absorption = ((string)drug.Elements().Where(x => x.Name.LocalName == "absorption").FirstOrDefault());
                int zk = absorption.Length;
                string half_life = ((string)drug.Elements().Where(x => x.Name.LocalName == "half-life").FirstOrDefault());
                int zl = half_life.Length;
                string protein_binding = ((string)drug.Elements().Where(x => x.Name.LocalName == "protein-binding").FirstOrDefault());
                int zm = protein_binding.Length;
                string route_of_elimination = ((string)drug.Elements().Where(x => x.Name.LocalName == "route-of-elimination").FirstOrDefault());
                int zn = route_of_elimination.Length;
                string volume_of_distribution = ((string)drug.Elements().Where(x => x.Name.LocalName == "volume-of-distribution").FirstOrDefault());
                int zo = volume_of_distribution.Length;
                string clearance = ((string)drug.Elements().Where(x => x.Name.LocalName == "clearance").FirstOrDefault());
                int zp = clearance.Length;
                drugCmd.Parameters["@Type"].Value = dType;
                drugCmd.Parameters["@Created"].Value = created;
                drugCmd.Parameters["@Updated"].Value = updated;
                drugCmd.Parameters["@ID"].Value = primaryID;
                drugCmd.Parameters["@Name"].Value = name;
                drugCmd.Parameters["@Description"].Value = description;
                drugCmd.Parameters["@Case_Number"].Value = case_number;
                drugCmd.Parameters["@Unii"].Value = unii;
                drugCmd.Parameters["@State"].Value = state;
                drugCmd.Parameters["@Synthesis_Reference"].Value = synthesis_reference;
                drugCmd.Parameters["@Indication"].Value = indication;
                drugCmd.Parameters["@Pharmacodynamics"].Value = pharmacodynamics;
                drugCmd.Parameters["@Mechanism_of_Action"].Value = mechanism_of_action;
                drugCmd.Parameters["@Toxicity"].Value = toxicity;
                drugCmd.Parameters["@Metabolism"].Value = metabolism;
                drugCmd.Parameters["@Absorption"].Value = absorption;
                drugCmd.Parameters["@Half_Life"].Value = half_life;
                drugCmd.Parameters["@Protein_Binding"].Value = protein_binding;
                drugCmd.Parameters["@Route_of_Elimination"].Value = route_of_elimination;
                drugCmd.Parameters["@Volume_of_Distribution"].Value = volume_of_distribution;
                drugCmd.Parameters["@Clearance"].Value = clearance;
                drugCmd.ExecuteNonQuery();
            }
            public void AddArticles(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("article")))
                {
                    string pubmed_id = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "pubmed-id").FirstOrDefault());
                    string citation = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "citation").FirstOrDefault());
                    articleCmd.Parameters["@ID"].Value = id;
                    articleCmd.Parameters["@Pubmed_ID"].Value = pubmed_id;
                    articleCmd.Parameters["@Citation"].Value = citation;
                    articleCmd.ExecuteNonQuery();
                }
                foreach (XElement article in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("link")))
                {
                    string title = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "title").FirstOrDefault());
                    string url = ((string)article.Elements().Where(XElement => XElement.Name.LocalName == "url").FirstOrDefault());
                    linkCmd.Parameters["@ID"].Value = id;
                    linkCmd.Parameters["@Title"].Value = title;
                    linkCmd.Parameters["@URL"].Value = url;
                    linkCmd.ExecuteNonQuery();
                }
            }
            public void AddInteractions(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement interaction in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("drug-interaction")))
                {
                    string interactionID = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "drugbank-id").FirstOrDefault()).Trim();
                    string description = ((string)interaction.Elements().Where(XElement => XElement.Name.LocalName == "description").FirstOrDefault());
                    interactionCmd.Parameters["@ID"].Value = id;
                    interactionCmd.Parameters["@Interaction_ID"].Value = interactionID;
                    interactionCmd.Parameters["@Description"].Value = description;
                    interactionCmd.ExecuteNonQuery();
                }
            }
            public void AddProducts(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement product in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("product")))
                {
                    string name = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "name").FirstOrDefault()).Trim();
                    string labeller = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "labeller").FirstOrDefault()).Trim();
                    string ndc_id = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ndc-id").FirstOrDefault());
                    string ndc_product_code = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ndc-product-code").FirstOrDefault());
                    string dpd_id = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "dpd-id").FirstOrDefault());
                    string ema_product_code = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ema-product-code").FirstOrDefault());
                    string ema_ma_number = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ema-ma-number").FirstOrDefault());
                    string started_marketing_onStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "started-marketing-on").FirstOrDefault());
                    string ended_marketing_onStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "ended-marketing-on").FirstOrDefault());
                    string dosage_form = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "dosage-form").FirstOrDefault());
                    string strength = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "strength").FirstOrDefault());
                    string route = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "route").FirstOrDefault());
                    string fda_application_number = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "fda-application-number").FirstOrDefault());
                    string genericStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "generic").FirstOrDefault());
                    byte? generic = string.IsNullOrEmpty(genericStr) ? null : ((genericStr == "true") ? (byte?)1 : (byte?)0);
                    string over_the_counterStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "over-the-counter").FirstOrDefault());
                    byte? over_the_counter = string.IsNullOrEmpty(over_the_counterStr) ? null : ((over_the_counterStr == "true") ? (byte?)1 : (byte?)0);
                    string approvedStr = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "approved").FirstOrDefault());
                    byte? approved = string.IsNullOrEmpty(approvedStr) ? null : ((approvedStr == "true") ? (byte?)1 : (byte?)0);
                    string country = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "country").FirstOrDefault());
                    string source = ((string)product.Elements().Where(XElement => XElement.Name.LocalName == "source").FirstOrDefault());
                    productCmd.Parameters["@ID"].Value = id;
                    productCmd.Parameters["@Name"].Value = name;
                    productCmd.Parameters["@Labeller"].Value = labeller;
                    productCmd.Parameters["@NDC_ID"].Value = ndc_id;
                    productCmd.Parameters["@NDC_Product_Code"].Value = ndc_product_code;
                    productCmd.Parameters["@DPD_ID"].Value = dpd_id;
                    productCmd.Parameters["@EMA_Product_Code"].Value = ema_product_code;
                    productCmd.Parameters["@EMA_MA_Number"].Value = ema_ma_number;
                    if (!string.IsNullOrEmpty(started_marketing_onStr))
                    {
                        productCmd.Parameters["@Started_Marketing_On"].Value = DateTime.Parse(started_marketing_onStr);
                    }
                    else
                    {
                        productCmd.Parameters["@Started_Marketing_On"].Value = new DateTime();
                    }
                    if (!string.IsNullOrEmpty(ended_marketing_onStr))
                    {
                        productCmd.Parameters["@Ended_Marketing_On"].Value = DateTime.Parse(ended_marketing_onStr);
                    }
                    else
                    {
                        productCmd.Parameters["@Ended_Marketing_On"].Value = new DateTime();
                    }
                    productCmd.Parameters["@Dosage_Form"].Value = dosage_form;
                    productCmd.Parameters["@Strength"].Value = strength;
                    productCmd.Parameters["@Route"].Value = route;
                    productCmd.Parameters["@FDA_Application_Number"].Value = fda_application_number;
                    productCmd.Parameters["@Generic"].Value = generic;
                    productCmd.Parameters["@Over_the_Counter"].Value = over_the_counter;
                    productCmd.Parameters["@Approved"].Value = approved;
                    productCmd.Parameters["@Country"].Value = country;
                    productCmd.Parameters["@Source"].Value = source;
                    productCmd.ExecuteNonQuery();
                }
            }
            public void AddMixtures(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement mixture in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("mixture")))
                {
                    string name = ((string)mixture.Elements().Where(XElement => XElement.Name.LocalName == "name").FirstOrDefault()).Trim();
                    string ingredient = ((string)mixture.Elements().Where(XElement => XElement.Name.LocalName == "ingredients").FirstOrDefault()).Trim();
                    mixtureCmd.Parameters["@ID"].Value = id;
                    mixtureCmd.Parameters["@Name"].Value = name;
                    mixtureCmd.Parameters["@Ingredients"].Value = ingredient;
                    mixtureCmd.ExecuteNonQuery();
                }
            }
            public void AddPackagers(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement packager in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("packager")))
                {
                    string name = ((string)packager.Elements().Where(XElement => XElement.Name.LocalName == "name").FirstOrDefault()).Trim();
                    string url = ((string)packager.Elements().Where(XElement => XElement.Name.LocalName == "url").FirstOrDefault()).Trim();
                    packagerCmd.Parameters["@ID"].Value = id;
                    packagerCmd.Parameters["@Name"].Value = name;
                    packagerCmd.Parameters["@URL"].Value = url;
     
                    packagerCmd.ExecuteNonQuery();
                    
                }
            }
            public void AddPrices(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement price in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("price")))
                {
                    string description = ((string)price.Elements().Where(XElement => XElement.Name.LocalName == "description").FirstOrDefault()).Trim();
                    XElement xCost = (price.Elements().Where(XElement => XElement.Name.LocalName == "cost").FirstOrDefault());
                    string cost = ((string)xCost).Trim();
                    string currency = (string)xCost.Attribute("currency");
                    string unit = ((string)price.Elements().Where(XElement => XElement.Name.LocalName == "unit").FirstOrDefault()).Trim();
                    priceCmd.Parameters["@ID"].Value = id;
                    priceCmd.Parameters["@Description"].Value = description;
                    priceCmd.Parameters["@Cost"].Value = cost;
                    priceCmd.Parameters["@Currency"].Value = currency;
                    priceCmd.Parameters["@Unit"].Value = unit;
     
                    priceCmd.ExecuteNonQuery();
                }
            }
            public void AddCategories(SqlConnection conn, XElement drug, string id)
            {
                XElement categories = drug.Descendants().Where(XElement => XElement.Name.LocalName == ("categories")).FirstOrDefault();
                foreach (XElement xCategory in categories.Elements().Where(XElement => XElement.Name.LocalName == ("category")))
                {
                    string category = ((string)xCategory.Elements().Where(XElement => XElement.Name.LocalName == "category").FirstOrDefault()).Trim();
                    string meshID = ((string)xCategory.Elements().Where(XElement => XElement.Name.LocalName == "mesh-id").FirstOrDefault()).Trim();
                    categoryCmd.Parameters["@ID"].Value = id;
                    categoryCmd.Parameters["@Category"].Value = category;
                    categoryCmd.Parameters["@Mesh_ID"].Value = meshID;
     
                    categoryCmd.ExecuteNonQuery();
                }
            }
            public void AddOrganisms(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement xOrganism in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("affected-organism")))
                {
                    string organism = ((string)xOrganism).Trim();
     
                    organismCmd.Parameters["@ID"].Value = id;
                    organismCmd.Parameters["@Organism"].Value = organism;
     
                    organismCmd.ExecuteNonQuery();
                    
                }
            }
            public void AddPatents(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement patent in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("patent")))
                {
                    string number = ((string)patent.Elements().Where(XElement => XElement.Name.LocalName == "number").FirstOrDefault()).Trim();
                    string country = ((string)patent.Elements().Where(XElement => XElement.Name.LocalName == "country").FirstOrDefault()).Trim();
                    DateTime approved = (DateTime)patent.Elements().Where(XElement => XElement.Name.LocalName == "approved").FirstOrDefault();
                    DateTime expires = (DateTime)patent.Elements().Where(XElement => XElement.Name.LocalName == "expires").FirstOrDefault();
                    string pediatric_extensionStr = ((string)patent.Elements().Where(XElement => XElement.Name.LocalName == "pediatric-extension").FirstOrDefault());
                    byte? pediatric_extension = string.IsNullOrEmpty(pediatric_extensionStr) ? null : ((pediatric_extensionStr == "true") ? (byte?)1 : (byte?)0);
                    patentCmd.Parameters["@ID"].Value = id;
                    patentCmd.Parameters["@Number"].Value = number;
                    patentCmd.Parameters["@Country"].Value = country;
                    patentCmd.Parameters["@Approved"].Value = approved;
                    patentCmd.Parameters["@Expires"].Value = expires;
                    patentCmd.Parameters["@Pediatric_Extension"].Value = pediatric_extension;
                    patentCmd.ExecuteNonQuery();
                }
            }
            public void AddSequences(SqlConnection conn, XElement drug, string id)
            {
                string format = "";
                string sequence = "";
                foreach (XElement xSequence in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("sequence")))
                {
                    format = (string)xSequence.Attribute("format");
                    sequence = ((string)xSequence).Trim();
                    
                    sequenceCmd.Parameters["@ID"].Value = id;
                    sequenceCmd.Parameters["@Format"].Value = format == null ? "" : format;
                    sequenceCmd.Parameters["@Type"].Value = "sequence";
                    sequenceCmd.Parameters["@Sequence"].Value =sequence;
     
                    sequenceCmd.ExecuteNonQuery(); 
                }
     
                XElement amino_acid_sequence = drug.Descendants().Where(XElement => XElement.Name.LocalName == ("amino-acid-sequence")).FirstOrDefault();
                if (amino_acid_sequence != null)
                {
                    format = (string)amino_acid_sequence.Attribute("format");
                    sequence = ((string)amino_acid_sequence).Trim();
                    sequenceCmd.Parameters["@ID"].Value = id;
                    sequenceCmd.Parameters["@Format"].Value = format;
                    sequenceCmd.Parameters["@Type"].Value = "amino-acid-sequence";
                    sequenceCmd.Parameters["@Sequence"].Value = sequence;
                    sequenceCmd.ExecuteNonQuery();
                }
                XElement gene_sequence = drug.Descendants().Where(XElement => XElement.Name.LocalName == ("gene-sequence")).FirstOrDefault();
                if (gene_sequence != null)
                {
                    format = (string)gene_sequence.Attribute("format");
                    sequence = ((string)gene_sequence).Trim();
                    sequenceCmd.Parameters["@ID"].Value = id;
                    sequenceCmd.Parameters["@Format"].Value = format;
                    sequenceCmd.Parameters["@Type"].Value = "gene_sequence";
                    sequenceCmd.Parameters["@Sequence"].Value = sequence;
                    sequenceCmd.ExecuteNonQuery();
                }
     
            }
            public void AddProperties(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement property in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("property")))
                {
                    string kind = ((string)property.Elements().Where(XElement => XElement.Name.LocalName == "kind").FirstOrDefault()).Trim();
                    string value = ((string)property.Elements().Where(XElement => XElement.Name.LocalName == "value").FirstOrDefault()).Trim();
                    string source = ((string)property.Elements().Where(XElement => XElement.Name.LocalName == "source").FirstOrDefault()).Trim();
                    propertyCmd.Parameters["@ID"].Value = id;
                    propertyCmd.Parameters["@Kind"].Value = kind;
                    propertyCmd.Parameters["@Value"].Value = value;
                    propertyCmd.Parameters["@Source"].Value = source;
     
                    propertyCmd.ExecuteNonQuery();
                }
            }
            public void AddIdentifiers(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement xIdentifier in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("external-identifier")))
                {
                    string resource = ((string)xIdentifier.Elements().Where(XElement => XElement.Name.LocalName == "resource").FirstOrDefault()).Trim();
                    string identifier = ((string)xIdentifier.Elements().Where(XElement => XElement.Name.LocalName == "identifier").FirstOrDefault()).Trim();
                    
                    identifierCmd.Parameters["@ID"].Value = id;
                    identifierCmd.Parameters["@Resource"].Value = resource;
                    identifierCmd.Parameters["@Identifier"].Value = identifier;
     
                    identifierCmd.ExecuteNonQuery();
                    
                }
            }
            public void AddEnzymes(SqlConnection conn, XElement drug, string id)
            {
                foreach (XElement enzyme in drug.Descendants().Where(XElement => XElement.Name.LocalName == ("uniprot-id")))
                {
                    string uniprot_id = (string)enzyme;
                    enzymCmd.Parameters["@ID"].Value = id;
                    enzymCmd.Parameters["@UniprotID"].Value = uniprot_id;
     
                    enzymCmd.ExecuteNonQuery();
                }
            }
        }
