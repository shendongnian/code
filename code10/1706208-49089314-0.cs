    	public Form1()
    			{
    						InitializeComponent();
    
    						XmlElement ndError = this.getError( "1101" );
    						string strDetails = "Error: " + ndError.GetAttribute( "classe");
    						strDetails += "\r\n" + ndError.GetAttribute( "Plage" );
    						strDetails += "\r\n" + ndError.GetAttribute( "Text" );
    				}
    
    				public XmlElement getError( string strError ) {
    						XmlDocument xml = new XmlDocument();
    						xml.LoadXml(@"
    <List>
    <ListingCodeErreur>
    <Erreur ID='1100' ><Definition classe='0' Plage='Général' Text='Parameters    inside'/></Erreur>
    <Erreur ID='1101' ><Definition classe='1' Plage='Général' Text='Parameters outside'/></Erreur>
    <Erreur ID='1102' ><Definition classe='2' Plage='Général' Text='Unknow parameters'/></Erreur>
    </ListingCodeErreur>
    
    <ClasseErreur>
    <Classe ID='0' ><Definition Text='Avertissement' Couleur='#145A14'/></Classe>
    <Classe ID='1' ><Definition Text='Stop' Couleur='#145A14'/></Classe>
    </ClasseErreur>
    </List>
    						");
    
    						XmlElement ndReturn = (XmlElement)xml.SelectSingleNode( "//Erreur[@ID='" + strError + "']/Definition");
    						return ndReturn;
    				}
