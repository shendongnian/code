    using System;
    using System.Collections.Generic;
    class Faction { 
        // the parent faction
        protected Faction _parent;
        // list of children factions
        protected List<Faction> _children = new List<Faction>();
        // the Faction knows the structure, so this approach is iterative but not
        // for this difficult to maintain.
        public void ModifyStanding(Player p,Decimal amount) {
            p[this] += amount;
            foreach (Faction child in _children) {
                child.ModifyStanding(p, amount / 2);
            }
        }
    }
    class Player {
        // standings
        Dictionary<Faction, Decimal> _standings = new Dictionary<Faction,decimal>();
        // get / set standing indexing on faction
        public Decimal this[Faction f] {
            get { return _standings[f]; }
            set { _standings[f] = value; }
        }
    }
