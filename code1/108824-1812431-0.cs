    function onFinish( selProj, selObj )
    {
      var strProjectPath = wizard.FindSymbol('PROJECT_PATH');
      var prjCpp;
      var prjCs;
      CreateProjects( strProjectPath, prjCpp, prjCs );
      //project config here
      prjCpp.Object.Save();
      prjCs.Object.Save();
      selProj = prjCpp;
    }
    
    function CreateProjects( path, prjCpp, prjCs )
    {
      var strProjTemplatePath = wizard.FindSymbol('ABSOLUTE_PATH'); //get template from our template dir
      var strProjTemplateCpp = strProjTemplatePath + '\\default.vcproj';
      var strProjTemplateCs = strProjTemplatePath + '\\default.csproj';
      var Solution = dte.Solution;
      if( wizard.FindSymbol( "CLOSE_SOLUTION" ) )
      {
        Solution.Close();
        strSolutionName = wizard.FindSymbol( "VS_SOLUTION_NAME" );
        if( strSolutionName.length )
        {
          var strSolutionPath = strProjectPath.substr( 0, strProjectPath.length - strProjectName.length );
          Solution.Create(strSolutionPath, strSolutionName);
        }
      }
      
      var oTarget = wizard.FindSymbol( "TARGET" );
      prjCpp = oTarget.AddFromTemplate( strProjTemplateCpp, strProjectPath, strProjectName + '.vcproj' );
      prjCs = oTarget.AddFromTemplate( strProjTemplateCs, strProjectPath, strProjectName + '.csproj' );
      Solution.Projects.Add( prjCpp );
      Solution.Projects.Add( prjCs );
    }
