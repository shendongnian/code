    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace myNamespace
    {
        /// <summary>
        /// Pour le confort et le bonheur, cette classe remplace StringBuilder pour la construction
        /// des requêtes SQL, avec l'avantage qu'elle gère la création des paramètres via la méthode
        /// Value().
        /// </summary>
        public class SqlBuilder
        {
            private StringBuilder _rq;
            private SqlCommand _cmd;
            private int _seq;
            public SqlBuilder(SqlCommand cmd)
            {
                _rq = new StringBuilder();
                _cmd = cmd;
                _seq = 0;
            }
            //Les autres surcharges de StringBuilder peuvent être implémenté ici de la même façon, au besoin.
            public SqlBuilder Append(String str)
            {
                _rq.Append(str);
                return this;
            }
            /// <summary>
            /// Ajoute une valeur runtime à la requête, via un paramètre.
            /// </summary>
            /// <param name="value">La valeur à renseigner dans la requête</param>
            /// <param name="type">Le DBType à utiliser pour la création du paramètre. Se référer au type de la colonne cible.</param>
            public SqlBuilder Value(Object value, SqlDbType type)
            {
                //get param name
                string paramName = "@SqlBuilderParam" + _seq++;
                //append condition to query
                _rq.Append(paramName);
                _cmd.Parameters.Add(paramName, type).Value = value;
                return this;
            }
            public SqlBuilder FuzzyValue(Object value, SqlDbType type)
            {
                //get param name
                string paramName = "@SqlBuilderParam" + _seq++;
                //append condition to query
                _rq.Append("'%' + " + paramName + " + '%'");
                _cmd.Parameters.Add(paramName, type).Value = value;
                return this; 
            }
            public override string ToString()
            {
                return _rq.ToString();
            }
        }
    }
