    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    public struct MerkmalRow
    {
        public string Name { get; }
        public string Wert { get; }
    
        public MerkmalRow(string name, string wert)
        {
            Name = name;
            Wert = wert;
        }
    }
    
    public class MerkmalSet
    {
        public HashSet<MerkmalRow> Merkmalls = new HashSet<MerkmalRow>();
    
        public void AddNewRow(MerkmalRow newRow) => Merkmalls.Add(newRow);
    }
    
    public class Tests 
    {
        [Fact]
        public void DuplicatesAreNotAdded() 
        {
            var merkmalSet = new MerkmalSet();
            merkmalSet.AddNewRow(new MerkmalRow("1", "2"));
            merkmalSet.AddNewRow(new MerkmalRow("1", "2"));
            merkmalSet.AddNewRow(new MerkmalRow("1", "2"));
            merkmalSet.AddNewRow(new MerkmalRow("1", "3"));
            
            Assert.Equal(2, merkmalSet.Merkmalls.Count);
        }
    }
