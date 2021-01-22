        public void LoadPropertyTypes()
        {
            Type t = this.GetType();
            System.Reflection.MemberInfo[] memberInfo = t.GetMembers();
            foreach (System.Reflection.MemberInfo mInfo in memberInfo)
            {
                string[] prop = mInfo.ToString().Split(Convert.ToChar(" "));
                propertyTable.Add(prop[1], prop[0]);
            }
        }
        public string GetMemberType(string propName)
        {
            if (propertyTable.ContainsKey(propName))
            {
                return Convert.ToString(propertyTable[propName]);
            }
            else{
                return "N/A";
            }
        }
