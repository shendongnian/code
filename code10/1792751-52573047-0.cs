    using System.Collections.Generic;
    
    public class ClasseTest : MonoBehaviour
    {
        public enum TiposDeMissoes
        {
            TipoMatarGente,
            TipoPegarItem,
        };
    	
        [Serializable]
        public class MatarGente
        {
            public int IDmissao;
            public GameObject[] ObjetosAtivarPraMissao;
            public GameObject[] Checkpoints;
            public GameObject[] InimigosPraMatar;
        }
    	
        [Serializable]
        public class PegarItem
        {
            public int IDmissao;
            public GameObject[] ObjetosAtivarPraMissao;
            public GameObject[] Checkpoints;
            public GameObject[] ItemsEntregar;
        }
    
        [Serializable]
        public class Missoes
        {
            public TiposDeMissoes TiposMissoes;
            public PegarItem[] PegarItem;
            public MatarGente[] MatarGente;
        }
    
        public List<Missoes> MissoesJogasso;
    }
    
