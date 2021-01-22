    <?xml version="1.0" encoding="utf-8"?>
    <edmx:Edmx Version="2.0" xmlns:edmx="http://schemas.microsoft.com/ado/2008/10/edmx">
      <!-- EF Runtime content -->
      <edmx:Runtime>
        <!-- SSDL content -->
        <edmx:StorageModels>
          <Schema Namespace="TestModel.Store" Alias="Self" Provider="System.Data.SqlClient" ProviderManifestToken="2005" xmlns:store="http://schemas.microsoft.com/ado/2007/12/edm/EntityStoreSchemaGenerator" xmlns="http://schemas.microsoft.com/ado/2009/02/edm/ssdl">
            <EntityContainer Name="TestModelStoreContainer">
              <EntitySet Name="Application" EntityType="TestModel.Store.Application" store:Type="Tables" Schema="dbo" />
              <EntitySet Name="DetailsControlSet" EntityType="TestModel.Store.DetailsControlSet" store:Type="Tables" Schema="dbo" />
              <AssociationSet Name="FK_Application_DetailsControlSet" Association="TestModel.Store.FK_Application_DetailsControlSet">
                <End Role="DetailsControlSet" EntitySet="DetailsControlSet" />
                <End Role="Application" EntitySet="Application" />
              </AssociationSet>
            </EntityContainer>
            <EntityType Name="Application">
              <Key>
                <PropertyRef Name="ApplicationName" />
              </Key>
              <Property Name="ApplicationName" Type="varchar" Nullable="false" MaxLength="50" />
              <Property Name="DetailsControlSetId" Type="int" />
            </EntityType>
            <EntityType Name="DetailsControlSet">
              <Key>
                <PropertyRef Name="DetailsControlSetId" />
              </Key>
              <Property Name="DetailsControlSetId" Type="int" Nullable="false" StoreGeneratedPattern="Identity" />
            </EntityType>
            <Association Name="FK_Application_DetailsControlSet">
              <End Role="DetailsControlSet" Type="TestModel.Store.DetailsControlSet" Multiplicity="0..1">
                <OnDelete Action="Cascade" />
              </End>
              <End Role="Application" Type="TestModel.Store.Application" Multiplicity="*" />
              <ReferentialConstraint>
                <Principal Role="DetailsControlSet">
                  <PropertyRef Name="DetailsControlSetId" />
                </Principal>
                <Dependent Role="Application">
                  <PropertyRef Name="DetailsControlSetId" />
                </Dependent>
              </ReferentialConstraint>
            </Association>
          </Schema>
        </edmx:StorageModels>
        <!-- CSDL content -->
        <edmx:ConceptualModels>
          <Schema Namespace="TestModel" Alias="Self" xmlns:annotation="http://schemas.microsoft.com/ado/2009/02/edm/annotation" xmlns="http://schemas.microsoft.com/ado/2008/09/edm">
            <EntityContainer Name="TestEntities" annotation:LazyLoadingEnabled="true">
              <EntitySet Name="Applications" EntityType="TestModel.Application" />
              <EntitySet Name="DetailsControlSets" EntityType="TestModel.DetailsControlSet" />
              <AssociationSet Name="FK_Application_DetailsControlSet" Association="TestModel.FK_Application_DetailsControlSet">
                <End Role="DetailsControlSet" EntitySet="DetailsControlSets" />
                <End Role="Application" EntitySet="Applications" />
              </AssociationSet>
            </EntityContainer>
            <EntityType Name="Application">
              <Key>
                <PropertyRef Name="ApplicationName" />
              </Key>
              <Property Name="ApplicationName" Type="String" Nullable="false" MaxLength="50" Unicode="false" FixedLength="false" />
              <Property Name="DetailsControlSetId" Type="Int32" />
              <NavigationProperty Name="DetailsControlSet" Relationship="TestModel.FK_Application_DetailsControlSet" FromRole="Application" ToRole="DetailsControlSet" />
            </EntityType>
            <EntityType Name="DetailsControlSet">
              <Key>
                <PropertyRef Name="DetailsControlSetId" />
              </Key>
              <Property Name="DetailsControlSetId" Type="Int32" Nullable="false" annotation:StoreGeneratedPattern="Identity" />
              <NavigationProperty Name="Applications" Relationship="TestModel.FK_Application_DetailsControlSet" FromRole="DetailsControlSet" ToRole="Application" />
            </EntityType>
            <Association Name="FK_Application_DetailsControlSet">
              <End Role="DetailsControlSet" Type="TestModel.DetailsControlSet" Multiplicity="0..1">
                <OnDelete Action="Cascade" />
              </End>
              <End Role="Application" Type="TestModel.Application" Multiplicity="*" />
              <ReferentialConstraint>
                <Principal Role="DetailsControlSet">
                  <PropertyRef Name="DetailsControlSetId" />
                </Principal>
                <Dependent Role="Application">
                  <PropertyRef Name="DetailsControlSetId" />
                </Dependent>
              </ReferentialConstraint>
            </Association>
          </Schema>
        </edmx:ConceptualModels>
        <!-- C-S mapping content -->
        <edmx:Mappings>
          <Mapping Space="C-S" xmlns="http://schemas.microsoft.com/ado/2008/09/mapping/cs">
            <EntityContainerMapping StorageEntityContainer="TestModelStoreContainer" CdmEntityContainer="TestEntities">
              <EntitySetMapping Name="Applications"><EntityTypeMapping TypeName="TestModel.Application"><MappingFragment StoreEntitySet="Application">
                <ScalarProperty Name="ApplicationName" ColumnName="ApplicationName" />
                <ScalarProperty Name="DetailsControlSetId" ColumnName="DetailsControlSetId" />
              </MappingFragment></EntityTypeMapping></EntitySetMapping>
              <EntitySetMapping Name="DetailsControlSets"><EntityTypeMapping TypeName="TestModel.DetailsControlSet"><MappingFragment StoreEntitySet="DetailsControlSet">
                <ScalarProperty Name="DetailsControlSetId" ColumnName="DetailsControlSetId" />
              </MappingFragment></EntityTypeMapping></EntitySetMapping>
            </EntityContainerMapping>
          </Mapping>
        </edmx:Mappings>
      </edmx:Runtime>
      <!-- EF Designer content (DO NOT EDIT MANUALLY BELOW HERE) -->
      <Designer xmlns="http://schemas.microsoft.com/ado/2008/10/edmx">
        <Connection>
          <DesignerInfoPropertySet>
            <DesignerProperty Name="MetadataArtifactProcessing" Value="EmbedInOutputAssembly" />
          </DesignerInfoPropertySet>
        </Connection>
        <Options>
          <DesignerInfoPropertySet>
            <DesignerProperty Name="ValidateOnBuild" Value="true" />
            <DesignerProperty Name="EnablePluralization" Value="True" />
            <DesignerProperty Name="IncludeForeignKeysInModel" Value="True" />
          </DesignerInfoPropertySet>
        </Options>
        <!-- Diagram content (shape and connector positions) -->
        <Diagrams>
          <Diagram Name="Model1">
            <EntityTypeShape EntityType="TestModel.Application" Width="1.5" PointX="3" PointY="0.875" Height="1.59568359375" IsExpanded="true" />
            <EntityTypeShape EntityType="TestModel.DetailsControlSet" Width="1.5" PointX="0.75" PointY="1" Height="1.4033821614583339" IsExpanded="true" />
            <AssociationConnector Association="TestModel.FK_Application_DetailsControlSet" ManuallyRouted="false">
              <ConnectorPoint PointX="2.25" PointY="1.701691080729167" />
              <ConnectorPoint PointX="3" PointY="1.701691080729167" />
            </AssociationConnector>
          </Diagram>
        </Diagrams>
      </Designer>
    </edmx:Edmx>
