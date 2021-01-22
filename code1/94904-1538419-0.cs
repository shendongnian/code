    public class clsPessoaMap : ClassMap<clsPessoa>
	{
		public clsPessoaMap()
		{
			Table("tblPessoa");
			Id(x => x.ID).Column("CodigoPessoa").UnsavedValue(0).GeneratedBy.Identity();
			Map(x => x.CodigoCEP);
		}
	}
	public class clsPessoaJuridicaMap : SubclassMap<clsPessoaJuridica>
	{
		public clsPessoaJuridicaMap()
		{
			KeyColumn("CodigoPessoaJuridica");
			Map(x => x.NomeFantasia);
			References(x => x.clsTipoEmpresa).Column("CodigoTipoEmpresa");
		}
	}
	public class clsPessoaFisicaMap: SubclassMap<clsPessoaFisica>
	{
		public clsPessoaFisicaMap()
		{
			KeyColumn("CodigoPessoaFisica");
			Map(x => x.Nome);
		}
	}
