     public class Card
            {
                public Card()
                {
                    DeckCardRelationships = new HashSet<DeckCardRelationship>();
                }
                public int Id { get; set; }
                public string Name { get; set; }
                public string Attribute { get; set; }
                public int Level { get; set; }
                public string Type { get; set; }
                public int ATK { get; set; }
                public int DEF { get; set; }
        
                public virtual Deck Deck { get; set; }
                public virtual ICollection<DeckCardRelationship> DeckCardRelationships { get; set; }
        
        
            }
        
            public class DeckCardRelationship
            {
                public int CardId { get; set; }
                public int DeckId { get; set; }
        
                public virtual Card Card { get; set; }
                public virtual Deck Deck { get; set; }
            }
        
            public class Deck
            {
                public Deck()
                {
                    DeckCardRelationships = new HashSet<DeckCardRelationship>();
                }
        
                public int Id { get; set; }
                public string DeckName { get; set; }
        
        
                public virtual ICollection<DeckCardRelationship> DeckCardRelationships { get; set; }
            }
