    <Analyzer AnalyzerId="StyleCop.CSharp.NamingRules">
        <Rules>
            <Rule Name="FieldNamesMustNotUseHungarianNotation">
              <RuleSettings>
                <BooleanProperty Name="Enabled">True</BooleanProperty>
              </RuleSettings>
            </Rule>
        </Rules>
        <AnalyzerSettings>
            <CollectionProperty Name="Hungarian">
                ...             
                <Value>fx</Value>
                ..                
            </CollectionProperty>      
       </AnalyzerSettings>
