    <!-- language: lang-csharp -->
    using System.Collections;
    using System.Collections.Generic;
    using EDV;
    
    namespace System.Windows.Forms
    {
        /// <summary>
        /// Cette classe est une implémentation de l'interface 'IComparer' pour le tri des items de ListView. Adapté de http://support.microsoft.com/kb/319401.
        /// </summary>
        /// <remarks>Intégré par EDVariables.</remarks>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Spécifie la colonne à trier
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Spécifie l'ordre de tri (en d'autres termes 'Croissant').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Objet de comparaison ne respectant pas les majuscules et minuscules
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;
    
            /// <summary>
            /// Constructeur de classe.  Initialise la colonne sur '0' et aucun tri
            /// </summary>
            public ListViewColumnSorter()
                : this(0, SortOrder.None) { }
    
            /// <summary>
            /// Constructeur de classe.  Initializes various elements
            /// <param name="columnToSort">Spécifie la colonne à trier</param>
            /// <param name="orderOfSort">Spécifie l'ordre de tri</param>
            /// </summary>
            public ListViewColumnSorter(int columnToSort, SortOrder orderOfSort)
            {
                // Initialise la colonne
                ColumnToSort = columnToSort;
    
                // Initialise l'ordre de tri
                OrderOfSort = orderOfSort;
    
                // Initialise l'objet CaseInsensitiveComparer
                ObjectCompare = new CaseInsensitiveComparer();
    
                // Dictionnaire de comparateurs
                ColumnsComparer = new Dictionary<int, IComparer>();
                ColumnsTypeComparer = new Dictionary<int, Type>();
    
            }
    
            /// <summary>
            /// Cette méthode est héritée de l'interface IComparer.  Il compare les deux objets passés en effectuant une comparaison 
            ///qui ne tient pas compte des majuscules et des minuscules.
            /// <br/>Si le comparateur n'existe pas dans ColumnsComparer, CaseInsensitiveComparer est utilisé.
            /// </summary>
            /// <param name="x">Premier objet à comparer</param>
            /// <param name="x">Deuxième objet à comparer</param>
            /// <returns>Le résultat de la comparaison. "0" si équivalent, négatif si 'x' est inférieur à 'y' 
            ///et positif si 'x' est supérieur à 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;
    
                // Envoit les objets à comparer aux objets ListViewItem
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;
    
                if (listviewX.SubItems.Count < ColumnToSort + 1 || listviewY.SubItems.Count < ColumnToSort + 1)
                    return 0;
    
                IComparer objectComparer = null;
                Type comparableType = null;
                if (ColumnsComparer == null || !ColumnsComparer.TryGetValue(ColumnToSort, out objectComparer))
                    if (ColumnsTypeComparer == null || !ColumnsTypeComparer.TryGetValue(ColumnToSort, out comparableType))
                        objectComparer = ObjectCompare;
    
                // Compare les deux éléments
                if (comparableType != null) {
                    //Conversion du type
                    object valueX = listviewX.SubItems[ColumnToSort].Text;
                    object valueY = listviewY.SubItems[ColumnToSort].Text;
                    if (!edvTools.TryParse(ref valueX, comparableType) || !edvTools.TryParse(ref valueY, comparableType))
                        return 0;
                    compareResult = (valueX as IComparable).CompareTo(valueY);
                }
                else
                    compareResult = objectComparer.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
    
                // Calcule la valeur correcte d'après la comparaison d'objets
                if (OrderOfSort == SortOrder.Ascending) {
                    // Le tri croissant est sélectionné, renvoie des résultats normaux de comparaison
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending) {
                    // Le tri décroissant est sélectionné, renvoie des résultats négatifs de comparaison
                    return (-compareResult);
                }
                else {
                    // Renvoie '0' pour indiquer qu'ils sont égaux
                    return 0;
                }
            }
    
            /// <summary>
            /// Obtient ou définit le numéro de la colonne à laquelle appliquer l'opération de tri (par défaut sur '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
    
            /// <summary>
            /// Obtient ou définit l'ordre de tri à appliquer (par exemple, 'croissant' ou 'décroissant').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
    
            /// <summary>
            /// Dictionnaire de comparateurs par colonne.
            /// <br/>Pendant le tri, si le comparateur n'existe pas dans ColumnsComparer, CaseInsensitiveComparer est utilisé.
            /// </summary>
            public Dictionary<int, IComparer> ColumnsComparer { get; set; }
    
            /// <summary>
            /// Dictionnaire de comparateurs par colonne.
            /// <br/>Pendant le tri, si le comparateur n'existe pas dans ColumnsTypeComparer, CaseInsensitiveComparer est utilisé.
            /// </summary>
            public Dictionary<int, Type> ColumnsTypeComparer { get; set; }
        }
    }
    	
