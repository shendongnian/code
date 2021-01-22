using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;
using Syncfusion.XlsIO;
namespace ExporteExcel
{
    class Program
    {
        public class Auto
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Ano { get; set; }
            public string Color { get; set; }
            public int Peronsas { get; set; }
            public int Cilindros { get; set; }
        }
        static void Main(string[] args)
        {
            //Lista Estatica
            List<Auto> Auto = new List<Program.Auto>()
            {
                new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2019, Color= "Azul", Cilindros=6, Peronsas= 4 },
                new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2018, Color= "Azul", Cilindros=6, Peronsas= 4 },
                new Auto{Marca = "Chevrolet", Modelo = "Sport", Ano = 2017, Color= "Azul", Cilindros=6, Peronsas= 4 }
            };
            //Inizializar Librerias
            var workbook = new XLWorkbook();
            workbook.AddWorksheet("sheetName");
            var ws = workbook.Worksheet("sheetName");
            //Recorrer el objecto
            int row = 1;
            foreach (var c in Auto)
            {
                //Escribrie en Excel en cada celda
                ws.Cell("A" + row.ToString()).Value = c.Marca;
                ws.Cell("B" + row.ToString()).Value = c.Modelo;
                ws.Cell("C" + row.ToString()).Value = c.Ano;
                ws.Cell("D" + row.ToString()).Value = c.Color;
                ws.Cell("E" + row.ToString()).Value = c.Cilindros;
                ws.Cell("F" + row.ToString()).Value = c.Peronsas;
                row++;
            }
            //Guardar Excel 
            //Ruta = Nombre_Proyecto\bin\Debug
            workbook.SaveAs("Coches.xlsx");
        }
    }
}
