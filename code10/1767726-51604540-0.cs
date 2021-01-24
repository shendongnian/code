    public class raizDoJson {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<resultado> results { get; set; }
    }
    public class resultado {
        public string original_name { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int vote_count { get; set; }
        public double vote_average { get; set; }
        public string poster_path { get; set; }
        public string first_air_date { get; set; }
        public int popularity { get; set; }
        public List<string> genre_ids { get; set; }
        public string original_language { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public List<string> origin_country { get; set; }
    }
