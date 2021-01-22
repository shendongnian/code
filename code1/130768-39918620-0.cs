    #region Références
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    #endregion
    
    namespace XmlSerializationTests
    {
    	/// <summary>
    	/// Représente une liste qui peut être sérialisée en XML en tant que noeud racine.
    	/// </summary>
    	/// <typeparam name="T">Type des éléments de la liste.</typeparam>
    	public class XmlSerializableList<T>
    		: List<T>, IXmlSerializable
    	{
    		#region Variables
    		private static readonly XmlSerializer _ItemSerializer = new XmlSerializer(typeof(T));
    		private static readonly string _ItemName;
    		private string _RootName;
    		#endregion
    
    		#region Méthodes
    		/// <summary>
    		/// Initialisation statique
    		/// </summary>
    		static XmlSerializableList()
    		{
    			_ItemName = (typeof(T).GetCustomAttributes(typeof(XmlRootAttribute), true).FirstOrDefault() as XmlRootAttribute)?.ElementName ?? typeof(T).Name;
    		}
    
    		/// <summary>
    		/// Obtient le nom racine.
    		/// </summary>
    		protected virtual string RootName
    		{
    			get
    			{
    				if (string.IsNullOrWhiteSpace(_RootName)) _RootName = (GetType().GetCustomAttributes(typeof(XmlRootAttribute), true).FirstOrDefault() as XmlRootAttribute)?.ElementName ?? GetType().Name;
    				return _RootName;
    			}
    		}
    
    		/// <summary>
    		/// Obtient le nom des éléments.
    		/// </summary>
    		protected virtual string ItemName
    		{
    			get { return _ItemName; }
    		}
    
    		/// <summary>
    		/// Cette méthode est réservée et ne doit pas être utilisée.Lorsque vous implémentez l'interface IXmlSerializable, vous devez retourner la valeur null (Nothing dans Visual Basic) à partir cette méthode et, si la spécification d'un schéma personnalisé est requise, appliquez à la place <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> à la classe.
    		/// </summary>
    		/// <returns> <see cref="T:System.Xml.Schema.XmlSchema"/> qui décrit la représentation XML de l'objet qui est généré par la méthode <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> et utilisé par la méthode <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/>.</returns>
    		public XmlSchema GetSchema()
    		{
    			return null;
    		}
    
    		/// <summary>
    		/// Génère un objet à partir de sa représentation XML.
    		/// </summary>
    		/// <param name="reader"><see cref="T:System.Xml.XmlReader"/> source à partir de laquelle l'objet est désérialisé.</param>
    		public void ReadXml(XmlReader reader)
    		{
    			if (!reader.IsEmptyElement)
    			{
    				reader.ReadStartElement();
    				while (reader.NodeType != XmlNodeType.EndElement)
    				{
    					T item = (T) _ItemSerializer.Deserialize(reader);
    					Add(item);
    				}
    				reader.ReadEndElement();
    			}
    			else reader.ReadStartElement();
    		}
    
    		/// <summary>
    		/// Convertit un objet en sa représentation XML.
    		/// </summary>
    		/// <param name="writer"><see cref="T:System.Xml.XmlWriter"/> flux dans lequel l'objet est sérialisé.</param>
    		public void WriteXml(XmlWriter writer)
    		{
    			foreach (var i in this)
    			{
    				XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    				ns.Add("", "");
    				_ItemSerializer.Serialize(writer, i, ns);
    			}
    		}
    		#endregion
    	}
    }
