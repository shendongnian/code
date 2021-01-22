    class RedirectionRule {
        public static RedirectionRule Parse(string text) {
            // some code here to parse text for your RedirectionRule object
        }
    
        public static RedirectionRule[] ParseCsv(string csv) {
            string[] values = csv.Split(',');
            RedirectionRule[] rules = new RedirectionRule[values.Length];
            
            for (int i = 0; i < values.Length; i++) {
                rules[i] = RedirectionRule.Parse(values[i]);
            }
        }
    }
