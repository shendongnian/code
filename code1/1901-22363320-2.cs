        public override int GetHashCode()
        {            
            var str = Convert.ToBase64String(Val);
            return str.GetHashCode();          
        }
