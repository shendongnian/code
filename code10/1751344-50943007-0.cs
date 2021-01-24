     using System.Collections.Generic;
    
        using Newtonsoft.Json;
    
        public partial class JsonModel
        {
            [JsonProperty("offset")]
            public long Offset { get; set; }
    
            [JsonProperty("limit")]
            public long Limit { get; set; }
    
            [JsonProperty("endOfRecords")]
            public bool EndOfRecords { get; set; }
    
            [JsonProperty("count")]
            public long Count { get; set; }
    
            [JsonProperty("results")]
            public List<Result> Results { get; set; }
        }
    
        public partial class Result
        {
            [JsonProperty("key")]
            public long Key { get; set; }
    
            [JsonProperty("datasetKey")]
            public string DatasetKey { get; set; }
    
            [JsonProperty("nubKey")]
            public long NubKey { get; set; }
    
            [JsonProperty("parentKey")]
            public long ParentKey { get; set; }
    
            [JsonProperty("parent")]
            public string Parent { get; set; }
    
            [JsonProperty("kingdom")]
            public string Kingdom { get; set; }
    
            [JsonProperty("phylum")]
            public string Phylum { get; set; }
    
            [JsonProperty("order")]
            public string Order { get; set; }
    
            [JsonProperty("family")]
            public string Family { get; set; }
    
            [JsonProperty("genus")]
            public string Genus { get; set; }
    
            [JsonProperty("kingdomKey")]
            public long KingdomKey { get; set; }
    
            [JsonProperty("phylumKey")]
            public long PhylumKey { get; set; }
    
            [JsonProperty("classKey")]
            public long ClassKey { get; set; }
    
            [JsonProperty("orderKey")]
            public long OrderKey { get; set; }
    
            [JsonProperty("familyKey")]
            public long FamilyKey { get; set; }
    
            [JsonProperty("genusKey")]
            public long GenusKey { get; set; }
    
            [JsonProperty("scientificName")]
            public string ScientificName { get; set; }
    
            [JsonProperty("canonicalName")]
            public string CanonicalName { get; set; }
    
            [JsonProperty("authorship")]
            public string Authorship { get; set; }
    
            [JsonProperty("nameType")]
            public string NameType { get; set; }
    
            [JsonProperty("taxonomicStatus")]
            public string TaxonomicStatus { get; set; }
    
            [JsonProperty("rank")]
            public string Rank { get; set; }
    
            [JsonProperty("origin")]
            public string Origin { get; set; }
    
            [JsonProperty("numDescendants")]
            public long NumDescendants { get; set; }
    
            [JsonProperty("numOccurrences")]
            public long NumOccurrences { get; set; }
    
            [JsonProperty("habitats")]
            public List<object> Habitats { get; set; }
    
            [JsonProperty("nomenclaturalStatus")]
            public List<object> NomenclaturalStatus { get; set; }
    
            [JsonProperty("threatStatuses")]
            public List<object> ThreatStatuses { get; set; }
    
            [JsonProperty("descriptions")]
            public List<object> Descriptions { get; set; }
    
            [JsonProperty("vernacularNames")]
            public List<object> VernacularNames { get; set; }
    
            [JsonProperty("higherClassificationMap")]
            public Dictionary<string, string> HigherClassificationMap { get; set; }
    
            [JsonProperty("synonym")]
            public bool Synonym { get; set; }
    
            [JsonProperty("class")]
            public string Class { get; set; }
        }
