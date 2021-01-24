    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Privilege
    {
        public string Type { get; }
        public string AccessType { get; }
        public string Value { get; }
        public string Action { get; }
        
        public Privilege(string type, string accessType, string value, string action)
        {
            Type = type;
            AccessType = accessType;
            Value = value;
            Action = action;
        }
    }
    
    class Test
    {
        static void Main()
        {
            var privileges = new List<Privilege>
            {
                // Bad: should cause an exception
                new Privilege("a", "a", "a", "a"),
                new Privilege("a", "a", "a", "b"),
    
                // Another bad one; let's check the
                // failure represents both
                new Privilege("x", "y", "z", "action1"),
                new Privilege("x", "y", "z", "action2"),
                
                // These have one property difference
                // in each case
                new Privilege("b", "a", "a", "a"),
                new Privilege("a", "b", "a", "a"),
                new Privilege("a", "a", "b", "a"),
    
                // Duplicate type/access/value, but same action too.
                new Privilege("d", "e", "f", "action"),
                new Privilege("d", "e", "f", "action")
            };
            CheckPrivileges(privileges);
        }
    
        static void CheckPrivileges(IEnumerable<Privilege> privileges)
        {
            var failures = privileges
                // Group the privileges by 3 properties, extracting actions as the values
                .GroupBy(p => new { p.Type, p.AccessType, p.Value }, p => p.Action)
                // Find any groups which have more than one distinct action
                .Where(g => g.Distinct().Skip(1).Any())
                .ToList();
    
            if (failures.Count > 0)
            {
                // There's at least one failure. There may be many. Throw
                // whatever exception you want here. This is just an example.
                var individualMessages =
                    failures.Select(g => $"{g.Key}: {string.Join(", ", g.Distinct())}");
                throw new Exception(
                    $"Invalid privilege combinations: {string.Join("; ", individualMessages)}");
            }
        }
    }
