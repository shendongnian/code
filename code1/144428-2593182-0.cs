    namespace Aesop.Dto
    {
        using System;
        using System.Xml.Serialization;
    
        /// <summary>
        /// Represents an Organization ID/Name combination.
        /// </summary>
        [Serializable]
        public sealed class Org
        {
            /// <summary>
            /// The organization's name.
            /// </summary>
            private readonly string name;
    
            /// <summary>
            /// The organization's ID.
            /// </summary>
            private readonly int id;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="Org"/> class.
            /// </summary>
            /// <param name="name">The organization's name.</param>
            /// <param name="id">The organization's ID.</param>
            public Org(string name, int id)
            {
                this.name = name;
                this.id = id;
            }
    
            /// <summary>
            /// Prevents a default instance of the <see cref="Org"/> class from
            /// being created.
            /// </summary>
            private Org()
            {
            }
    
            /// <summary>
            /// Gets or sets the organization's name.
            /// </summary>
            /// <value>The organization's name.</value>
            [XmlAttribute]
            public string Name
            {
                get
                {
                    return this.name;
                }
    
                set
                {
                }
            }
    
            /// <summary>
            /// Gets or sets the organization's ID.
            /// </summary>
            /// <value>The organization's ID.</value>
            [XmlAttribute]
            public int ID
            {
                get
                {
                    return this.id;
                }
    
                set
                {
                }
            }
        }
    }
