    class Enemigo : Personaje
    {
        public Enemigo(Rango Damage, int Defensa, int HP, bool Evade, bool Counter, string Nombre)
           : base(Damage, Defensa, HP, Evade, Counter, Nombre)
        {
        }
    }
    class Poring:Enemigo
    {
           public Poring(Rango Damage, int Defensa, int HP, bool Evade, bool Counter, string Nombre)
              : base(Damage, Defensa, HP, Evade, Counter, Nombre)
              {
              }
    }
