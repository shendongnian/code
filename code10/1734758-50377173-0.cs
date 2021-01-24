         using FluentMigrator;
    
    namespace test
    {
        [Migration(201805041513)]
        public class _201805041513_CriacaoTabelaPessoa : ForwardOnlyMigration
        {
            public override void Up()
            {
                Create.Table("Pessoa")
                    .InSchema("angularCore")
                    .WithColumn("Id").AsInt32().Identity()
                    .WithColumn("Nome").AsString(80)
                    .WithColumn("SobreNome").AsString(50)
                    .WithColumn("Email").AsString(50)
                    .WithColumn("IdTpoPessoa").AsInt16()
                    .WithColumn("IdEndereco").AsInt16();
    
    
            }
        }
    }
